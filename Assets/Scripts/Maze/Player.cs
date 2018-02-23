using UnityEngine;

public class Player : MonoBehaviour {

	private MazeCell currentCell;

	private MazeDirection currentDirection;

    public float speed;
    public float checkDist;
    //bool interacting;
    public int itemCount;

    float xInput;
    float yInput;

    Vector3 dir;
    Rigidbody rb;
    public enum LastInput { up, left, right, down };
    public LastInput lastInput;

    Vector3 previousGood = Vector3.zero;
    RaycastHit foundHit;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        //interacting = false;
        itemCount = PlayerPrefs.GetInt("itemCount");
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            foundHit = new RaycastHit();
            bool test = Physics.Raycast(transform.position, dir, out foundHit, checkDist, 1 << LayerMask.NameToLayer("Wall"));
            Debug.DrawRay(transform.position, dir, Color.green);

            if (test)//foundHit.collider != null)
            {
                Debug.Log("Looking at a thing: " + foundHit.transform.name);
                foundHit.transform.GetComponent<InteractParent>().Interact();
                //interacting = true;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (!interacting)
        //{
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
        //}
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