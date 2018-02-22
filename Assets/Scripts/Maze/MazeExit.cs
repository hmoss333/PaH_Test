using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeExit : MonoBehaviour {

    GameManager gm;
    
    // Use this for initialization
	void Start () {
        gm = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gm.RestartGame();
        }
    }
}
