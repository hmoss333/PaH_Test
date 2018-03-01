using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Test : MonoBehaviour {

    public float mouseSensitivity;
    float horizontal;
    float vertical;

    float xInput;
    float yInput;
    CharacterController cc;
    Vector3 dir;
    public float speed;
    public float gravity;

	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateRotation();

        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        dir = new Vector3(xInput, 0, yInput);
        dir = transform.TransformDirection(dir);
        dir *= speed;

        cc.Move(dir * Time.deltaTime);
    }

    void UpdateRotation()
    {
        horizontal = Input.GetAxis("Mouse X") * mouseSensitivity;
        vertical -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        vertical = Mathf.Clamp(vertical, -80, 80);

        transform.Rotate(0, horizontal, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(vertical, 0, 0);
    }

}
