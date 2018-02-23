using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractParent : MonoBehaviour {

    public Player player;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player == null)
            player = GameObject.FindObjectOfType<Player>();
    }

    public virtual void Interact ()
    {

    }
}
