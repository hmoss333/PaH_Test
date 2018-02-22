using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Maze : MonoBehaviour {

	public IntVector2 size;

	public MazeCell cellPrefab;
    public float cellScale;

	public float generationStepDelay;

	public MazePassage passagePrefab;

	public MazeDoor doorPrefab;

	[Range(0f, 1f)]
	public float doorProbability;

	public MazeWall[] wallPrefabs;

	public MazeRoomSettings[] roomSettings;

	public MazeCell[,] cells;

	private List<MazeRoom> rooms = new List<MazeRoom>();

	public IntVector2 RandomCoordinates {
		get {
			return new IntVector2(Random.Range(0, size.x), Random.Range(0, size.z)); //
		}
	}

    public GameObject[] interactObject;
    public int numOfInteracts; //per cell
    [Range(0f, 1f)]
    public float interactProbability;

    public MazeExit exitPrefab;


    public bool ContainsCoordinates (IntVector2 coordinate) {
		return coordinate.x >= 0 && coordinate.x < size.x && coordinate.z >= 0 && coordinate.z < size.z;
	}

	public MazeCell GetCell (IntVector2 coordinates) {
		return cells[coordinates.x, coordinates.z];
	}

	public IEnumerator Generate () {
		WaitForSeconds delay = new WaitForSeconds(generationStepDelay);
		cells = new MazeCell[size.x, size.z];
		List<MazeCell> activeCells = new List<MazeCell>();
		DoFirstGenerationStep(activeCells);
		while (activeCells.Count > 0) {
			yield return delay;
			DoNextGenerationStep(activeCells);
		}
        for (int i = 0; i < rooms.Count; i++)
        {
            rooms[i].Hide();
        }
    }

    private void DoFirstGenerationStep (List<MazeCell> activeCells) {
		MazeCell newCell = CreateCell(RandomCoordinates);
		newCell.Initialize(CreateRoom(-1));
		activeCells.Add(newCell);
	}

	private void DoNextGenerationStep (List<MazeCell> activeCells) {
        int currentIndex = activeCells.Count - 1;
		MazeCell currentCell = activeCells[currentIndex];
		if (currentCell.IsFullyInitialized) {
			activeCells.RemoveAt(currentIndex);
			return;
		}
		MazeDirection direction = currentCell.RandomUninitializedDirection;
		IntVector2 coordinates = currentCell.coordinates + direction.ToIntVector2();
		if (ContainsCoordinates(coordinates)) {
			MazeCell neighbor = GetCell(coordinates);
			if (neighbor == null) {
				neighbor = CreateCell(coordinates);
				CreatePassage(currentCell, neighbor, direction);
				activeCells.Add(neighbor);
			}
			else if (currentCell.room.settingsIndex == neighbor.room.settingsIndex) {
				CreatePassageInSameRoom(currentCell, neighbor, direction);
			}
			else {
				CreateWall(currentCell, neighbor, direction);
			}
		}
		else {
			CreateWall(currentCell, null, direction);
		}
	}

	private MazeCell CreateCell (IntVector2 coordinates) {
		MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
        ScaleObject(newCell.gameObject, cellScale, cellScale);
		cells[coordinates.x, coordinates.z] = newCell;
		newCell.coordinates = coordinates;
		newCell.name = "Maze Cell " + coordinates.x + ", " + coordinates.z;
		newCell.transform.parent = transform;
        //newCell.transform.localPosition = new Vector3(coordinates.x - size.x * 0.5f + 0.5f, 0f, coordinates.z - size.z * 0.5f + 0.5f); //original line
        newCell.transform.localPosition = new Vector3(coordinates.x * cellScale, 0f, coordinates.z * cellScale); //new line

        GameObject iObject;
        for (int i = 0; i < numOfInteracts; i++)
        {
            if (Random.value < interactProbability)
            {
                if (GameObject.FindObjectOfType<MazeExit>())
                {
                    iObject = Instantiate(interactObject[Random.Range(0, interactObject.Length)]);
                    iObject.transform.parent = newCell.transform;
                    float radius = iObject.GetComponent<SphereCollider>().radius;
                    iObject.transform.position = new Vector3(
                        Random.Range(newCell.transform.position.x - (cellScale / 2) + radius, newCell.transform.localPosition.x + (cellScale / 2) - radius), 
                        0, 
                        Random.Range(newCell.transform.localPosition.z - (cellScale / 2) + radius, newCell.transform.localPosition.z + (cellScale / 2) - radius));
                }
                else
                {
                    iObject = Instantiate(exitPrefab.gameObject);
                    iObject.transform.parent = newCell.transform;
                    iObject.transform.position = newCell.transform.position;
                }
            }
        }

        return newCell;
	}

	private void CreatePassage (MazeCell cell, MazeCell otherCell, MazeDirection direction) {
		MazePassage prefab = Random.value < doorProbability ? doorPrefab : passagePrefab;
        if (prefab == doorPrefab)
            ScaleObject(prefab.gameObject, cellScale, 1);

		MazePassage passage = Instantiate(prefab) as MazePassage;
		passage.Initialize(cell, otherCell, direction);
		passage = Instantiate(prefab) as MazePassage;

		if (passage is MazeDoor) {
			otherCell.Initialize(CreateRoom(cell.room.settingsIndex));
		}
		else {
			otherCell.Initialize(cell.room);
		}

		passage.Initialize(otherCell, cell, direction.GetOpposite());
	}

	private void CreatePassageInSameRoom (MazeCell cell, MazeCell otherCell, MazeDirection direction) {
		MazePassage passage = Instantiate(passagePrefab) as MazePassage;
		passage.Initialize(cell, otherCell, direction);
		passage = Instantiate(passagePrefab) as MazePassage;
		passage.Initialize(otherCell, cell, direction.GetOpposite());
		if (cell.room != otherCell.room) {
			MazeRoom roomToAssimilate = otherCell.room;
			cell.room.Assimilate(roomToAssimilate);
			rooms.Remove(roomToAssimilate);
			Destroy(roomToAssimilate);
		}
	}

	private void CreateWall (MazeCell cell, MazeCell otherCell, MazeDirection direction) {
		MazeWall wall = Instantiate(wallPrefabs[Random.Range(0, wallPrefabs.Length)]) as MazeWall;
        ScaleObject(wall.gameObject, cellScale, 1);
        wall.Initialize(cell, otherCell, direction);
		if (otherCell != null) {
			wall = Instantiate(wallPrefabs[Random.Range(0, wallPrefabs.Length)]) as MazeWall;
            ScaleObject(wall.gameObject, cellScale, 1);
            wall.Initialize(otherCell, cell, direction.GetOpposite());
		}
	}

	private MazeRoom CreateRoom (int indexToExclude) {
		MazeRoom newRoom = ScriptableObject.CreateInstance<MazeRoom>();
		newRoom.settingsIndex = Random.Range(0, roomSettings.Length);
		if (newRoom.settingsIndex == indexToExclude) {
			newRoom.settingsIndex = (newRoom.settingsIndex + 1) % roomSettings.Length;
		}
		newRoom.settings = roomSettings[newRoom.settingsIndex];
		rooms.Add(newRoom);
		return newRoom;
	}

    void ScaleObject (GameObject targetObject, float x, float z)
    {
        targetObject.transform.localScale = new Vector3(x, 1, z);
    }
}