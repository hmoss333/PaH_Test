using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : EnemyParent {

    public float noticeDist;
    public float attackDist;
    [SerializeField] bool attacking;

    public float speed;

    //public int health; //may move to separate script, if we keep it at all

    Player player;
    
    // Use this for initialization
	void Start () {
        attacking = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (player == null)
            player = GameObject.FindObjectOfType<Player>();

        else
        {
            Vector3 localPos = player.transform.position - transform.position;

            if (localPos.magnitude < attackDist && !attacking)
            {
                attacking = true;
                localPos = localPos.normalized;
                transform.Translate(0, 0, 0);
                //Debug.Log("attacking...");
            }
            else if (localPos.magnitude < noticeDist)
            {
                localPos = localPos.normalized;
                transform.Translate(localPos.x * speed * Time.deltaTime, 0, localPos.z * speed * Time.deltaTime);
            }
        }
	}
}
