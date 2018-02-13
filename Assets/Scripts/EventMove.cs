using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMove : MonoBehaviour {

    public float speed = 2.5f;
    public float waitPos;

    public bool completed;
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > waitPos && !completed)
            transform.Translate(Vector2.left * speed * Time.deltaTime);

        else if (completed)
            transform.Translate(Vector2.left * speed * Time.deltaTime);
	}
}
