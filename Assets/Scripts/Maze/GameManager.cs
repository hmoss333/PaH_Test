using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public Maze[] mazePrefabs;

	public Player playerPrefab;

	private Maze mazeInstance;

	private Player playerInstance;

	private void Start () {
        SceneManager.LoadSceneAsync("Loading", LoadSceneMode.Additive);
        PlayerPrefs.SetInt("itemCount", 0);
        StartCoroutine(BeginGame());
	}
	
	private void Update () {
        
    }

	private IEnumerator BeginGame () {
        //Camera.main.clearFlags = CameraClearFlags.Skybox;
        //Camera.main.rect = new Rect(0f, 0f, 1f, 1f);
        mazeInstance = Instantiate(PickMaze(mazePrefabs)) as Maze; //Instantiate(mazePrefabs) as Maze;
		yield return StartCoroutine(mazeInstance.Generate());
		playerInstance = Instantiate(playerPrefab) as Player;
		//playerInstance.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));
        //Camera.main.clearFlags = CameraClearFlags.Depth;
        //Camera.main.rect = new Rect(0f, 0f, 0.5f, 0.5f);
        SceneManager.UnloadSceneAsync("Loading");
	}

	public void RestartGame () {
		StopAllCoroutines();
        SceneManager.LoadSceneAsync("Loading", LoadSceneMode.Additive);
		Destroy(mazeInstance.gameObject);
		if (playerInstance != null) {
			Destroy(playerInstance.gameObject);
		}
		StartCoroutine(BeginGame());
	}

    private Maze PickMaze (Maze[] mazes)
    {
        int randNum = Random.Range(0, mazes.Length);
        Maze pickedMaze = mazes[randNum];

        return pickedMaze;
    }
}