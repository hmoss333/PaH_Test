using UnityEngine;

public class Player : MonoBehaviour {

	private MazeCell currentCell;

	private MazeDirection currentDirection;

    public float speed;
    public float checkDist;
    bool interacting;

    float xInput;
    float yInput;

    Vector3 dir;
    Rigidbody rb;
    [HideInInspector]
    public enum LastInput { up, left, right, down };
    public LastInput lastInput;

    Vector3 previousGood = Vector3.zero;
    RaycastHit2D foundHit;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        interacting = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!interacting)
        {
            xInput = Input.GetAxisRaw("Horizontal");
            yInput = Input.GetAxisRaw("Vertical");

            if (xInput != 0)
            {
                dir = new Vector3(xInput * speed, 0, 0);
                if (xInput > 0)
                {
                    lastInput = LastInput.right;
                }
                else
                {
                    lastInput = LastInput.left;
                }
            }
            else if (yInput != 0)
            {
                dir = new Vector3(0, 0, yInput * speed);
                if (yInput > 0)
                {
                    lastInput = LastInput.up;
                }
                else
                {
                    lastInput = LastInput.down;
                }
            }
            else
            {
                dir = new Vector3(0, 0, 0);
            }

            rb.velocity = dir;

            if (dir == Vector3.zero)
            {
                dir = previousGood;
            }
            else
            {
                previousGood = dir;
            }

            if (Input.GetButtonDown("Jump"))
            {
                foundHit = Physics2D.Raycast(transform.position, dir, checkDist, 1 << LayerMask.NameToLayer("Wall"));
                Debug.DrawRay(transform.position, dir, Color.green);

                if (foundHit.collider != null)
                {
                    Debug.Log("Looking at a thing: " + foundHit.transform.name);
                    //foundHit.collider.gameObject.GetComponent<Object_Interact_Parent>().Interact();
                    interacting = true;
                }
            }
        }
    }

    public void SetLocation(MazeCell cell)
    {
        if (currentCell != null)
        {
            currentCell.OnPlayerExited();
        }
        currentCell = cell;
        transform.localPosition = cell.transform.localPosition;
        currentCell.OnPlayerEntered();
    }

}