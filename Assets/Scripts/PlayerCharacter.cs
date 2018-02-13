using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

    public enum Races { white, black, asian, sAmer, other }
    public Races race;

    public enum Classes { lower, middle, upper }
    public Classes classes;

    public float money;

    // Use this for initialization
    void Start () {
        RandomRace();
        RandomClass();
	}
	
	// Update is called once per frame
	void Update () {
        if (money < 0f)
            Debug.Log("Game over");
	}

    void RandomRace()
    {
        int randNum = Random.Range(0, 5);

        switch (randNum)
        {
            case 0:
                race = Races.white;
                break;
            case 1:
                race = Races.black;
                break;
            case 2:
                race = Races.asian;
                break;
            case 3:
                race = Races.sAmer;
                break;
            case 4:
                race = Races.other;
                break;
            default:
                race = Races.other;
                break;
        }
    }

    void RandomClass ()
    {
        int randNum = Random.Range(0, 3);

        switch (randNum)
        {
            case 0:
                classes = Classes.lower;
                money = 10000f;
                break;
            case 1:
                classes = Classes.middle;
                money = 60000f;
                break;
            case 2:
                classes = Classes.upper;
                money = 120000f;
                break;
            default:
                classes = Classes.middle;
                break;
        }
    }
}
