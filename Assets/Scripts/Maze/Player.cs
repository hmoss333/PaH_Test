using UnityEngine;

public class Player : MonoBehaviour {

	private MazeCell currentCell;

	private MazeDirection currentDirection;

    public float speed;
    public float checkDist;
    public int itemCount;

    float xInput;
    float yInput;

    float horizontal;
    float vertical;
    public float mouseSensitivity;

    Vector3 dir;
    Rigidbody rb;

    Vector3 previousGood = Vector3.zero;
    RaycastHit foundHit;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        itemCount = PlayerPrefs.GetInt("itemCount");
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateRotation();

        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        dir = new Vector3(xInput, 0, yInput);
        dir = transform.TransformDirection(dir);
        dir *= speed;

        rb.velocity = dir;


        if (Input.GetMouseButtonDown(0))//.GetButtonDown("Jump"))
        {
            foundHit = new RaycastHit();
            bool test = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out foundHit, checkDist, 1 << LayerMask.NameToLayer("Wall"));
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.green);

            if (test)
            {
                foundHit.transform.GetComponent<InteractParent>().Interact();
            }
        }
    }

    void UpdateRotation()
    {
        horizontal = Input.GetAxis("Mouse X") * mouseSensitivity;
        vertical -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        vertical = Mathf.Clamp(vertical, -30, 30);

        transform.Rotate(0, horizontal, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(vertical, 0, 0);
    }

    public void SetLocation(MazeCell cell)
    {
        if (currentCell != null)
        {
            currentCell.OnPlayerExited();
        }
        currentCell = cell;
        transform.localPosition = new Vector3(cell.transform.localPosition.x, transform.position.y, cell.transform.localPosition.z);
        currentCell.OnPlayerEntered();
    }

}