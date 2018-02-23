using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {

    public MazeDoor mazeDoor;
    
    // Use this for initialization
	void Start () {
        mazeDoor = GetComponentInParent<MazeDoor>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            mazeDoor.OnPlayerEntered();
            //Debug.Log("entered new room");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //mazeDoor.OnPlayerExited();
            //Debug.Log("left old room");
        }
    }
}
