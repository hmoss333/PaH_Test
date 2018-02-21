using UnityEngine;

public abstract class MazeCellEdge : MonoBehaviour {

	public MazeCell cell, otherCell;

	public MazeDirection direction;

    //public Maze maze;
    private float scale;

    public virtual void Initialize (MazeCell cell, MazeCell otherCell, MazeDirection direction) {
		this.cell = cell;
		this.otherCell = otherCell;
		this.direction = direction;
		cell.SetEdge(direction, this);
		transform.parent = cell.transform;
        //transform.localPosition = Vector3.zero;

        Maze maze = GameObject.FindObjectOfType<Maze>();
        scale = maze.cellScale;

        switch (direction)
        {
            case MazeDirection.East:
                transform.localPosition = new Vector3(scale / 8f, 0, 0);//0.4f, 0, 0);
                break;
            case MazeDirection.West:
                transform.localPosition = new Vector3(-scale / 8f, 0, 0);//-0.4f, 0, 0);
                break;
            case MazeDirection.North:
                transform.localPosition = new Vector3(0, 0, scale / 8f);//0.4f);
                break;
            case MazeDirection.South:
                transform.localPosition = new Vector3(0, 0, -scale / 8f);//-0.4f);
                break;
            default:
                transform.localPosition = Vector3.zero;
                break;
        }

		transform.localRotation = direction.ToRotation();
	}

	public virtual void OnPlayerEntered () {}

	public virtual void OnPlayerExited () {}
}