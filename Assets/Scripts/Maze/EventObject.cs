using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventObject : MonoBehaviour {

	public enum Races { white, black, asian, sAmer, other}
    public Races race;

    public enum Classes { lower, middle, upper}
    public Classes classes;

    public int storyLevel;

    EventGenerator eg;
    EventMove em;
    PlayerCharacter player;
    
    // Use this for initialization
	void Start () {
        eg = GameObject.FindObjectOfType<EventGenerator>();
        em = GetComponent<EventMove>();
        player = GameObject.FindObjectOfType<PlayerCharacter>();

        //PlayEvent(race, classes, player.money);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space"))
        {
            PlayEvent(race, classes, player.money);
            em.completed = true;
        }
	}

    void PlayEvent (Races targetRace, Classes targetClass, float targetMoney)
    {
        Debug.Log("Event type: " + targetRace + " \n " + targetClass + " \n " + targetMoney);

        switch (targetClass)
        {
            case Classes.lower:
                switch (targetRace)
                {
                    case Races.white:
                        if (targetMoney < 1000f)
                        {
                            targetMoney += 1000f;
                            Debug.Log("Welfare");
                        }
                        else if (targetMoney < 10000)
                        {
                            targetMoney += 400f;
                            Debug.Log("Holiday bonus");
                        }
                        else if (targetMoney > 20000)
                        {
                            targetMoney -= 1200f;
                            Debug.Log("Income tax");
                        }
                        else
                        {
                            targetMoney -= 200f;
                            Debug.Log("Living expense");
                        }
                        break;
                    case Races.black:
                        if (targetMoney < 800f)
                        {
                            targetMoney += 800f;
                            Debug.Log("Welfare");
                        }
                        else if (targetMoney < 8000)
                        {
                            targetMoney += 400f;
                            Debug.Log("Holiday bonus");
                        }
                        else if (targetMoney > 10000)
                        {
                            targetMoney -= 1200f;
                            Debug.Log("Income tax");
                        }
                        else
                        {
                            targetMoney -= 200f;
                            Debug.Log("Living expense");
                        }
                        break;
                    case Races.asian:
                        if (targetMoney < 1200f)
                        {
                            targetMoney += 600f;
                            Debug.Log("Welfare");
                        }
                        else if (targetMoney < 12000)
                        {
                            targetMoney += 500f;
                            Debug.Log("Holiday bonus");
                        }
                        else if (targetMoney > 10000)
                        {
                            targetMoney -= 1400f;
                            Debug.Log("Income tax");
                        }
                        else
                        {
                            targetMoney -= 200f;
                            Debug.Log("Living expense");
                        }
                        break;
                    case Races.sAmer:
                        if (targetMoney < 800f)
                        {
                            targetMoney += 800f;
                            Debug.Log("Welfare");
                        }
                        else if (targetMoney < 8000)
                        {
                            targetMoney += 400f;
                            Debug.Log("Holiday bonus");
                        }
                        else if (targetMoney > 10000)
                        {
                            targetMoney -= 1200f;
                            Debug.Log("Income tax");
                        }
                        else
                        {
                            targetMoney -= 200f;
                            Debug.Log("Living expense");
                        }
                        break;
                    case Races.other:
                        if (targetMoney < 800f)
                        {
                            targetMoney += 800f;
                            Debug.Log("Welfare");
                        }
                        else if (targetMoney < 8000)
                        {
                            targetMoney += 400f;
                            Debug.Log("Holiday bonus");
                        }
                        else if (targetMoney > 10000)
                        {
                            targetMoney -= 1200f;
                            Debug.Log("Income tax");
                        }
                        else
                        {
                            targetMoney -= 200f;
                            Debug.Log("Living expense");
                        }
                        break;
                    default:
                        break;
                }
                break;
            case Classes.middle:
                switch (targetRace)
                {
                    case Races.white:
                        if (targetMoney < 18000f)
                        {
                            targetMoney += 900f;
                            Debug.Log("Welfare");
                        }
                        else if (targetMoney < 40000f)
                        {
                            targetMoney += 1000f;
                            Debug.Log("Holiday bonus");
                        }
                        else if (targetMoney > 80000f)
                        {
                            targetMoney -= 2000f;
                            Debug.Log("Income tax");
                        }
                        else
                        {
                            targetMoney -= 200f;
                            Debug.Log("Living expense");
                        }
                        break;
                    case Races.black:
                        if (targetMoney < 12000f)
                        {
                            targetMoney += 900f;
                            Debug.Log("Welfare");
                        }
                        else if (targetMoney < 45000f)
                        {
                            targetMoney += 1000f;
                            Debug.Log("Holiday bonus");
                        }
                        else if (targetMoney > 60000f)
                        {
                            targetMoney -= 2000f;
                            Debug.Log("Income tax");
                        }
                        else
                        {
                            targetMoney -= 200f;
                            Debug.Log("Living expense");
                        }
                        break;
                    case Races.asian:
                        if (targetMoney < 12000f)
                        {
                            targetMoney += 900f;
                            Debug.Log("Welfare");
                        }
                        else if (targetMoney < 45000f)
                        {
                            targetMoney += 1000f;
                            Debug.Log("Holiday bonus");
                        }
                        else if (targetMoney > 60000f)
                        {
                            targetMoney -= 2000f;
                            Debug.Log("Income tax");
                        }
                        else
                        {
                            targetMoney -= 200f;
                            Debug.Log("Living expense");
                        }
                        break;
                    case Races.sAmer:
                        if (targetMoney < 12000f)
                        {
                            targetMoney += 900f;
                            Debug.Log("Welfare");
                        }
                        else if (targetMoney < 45000f)
                        {
                            targetMoney += 1000f;
                            Debug.Log("Holiday bonus");
                        }
                        else if (targetMoney > 60000f)
                        {
                            targetMoney -= 2000f;
                            Debug.Log("Income tax");
                        }
                        else
                        {
                            targetMoney -= 200f;
                            Debug.Log("Living expense");
                        }
                        break;
                    case Races.other:
                        if (targetMoney < 12000f)
                        {
                            targetMoney += 900f;
                            Debug.Log("Welfare");
                        }
                        else if (targetMoney < 45000f)
                        {
                            targetMoney += 1000f;
                            Debug.Log("Holiday bonus");
                        }
                        else if (targetMoney > 60000f)
                        {
                            targetMoney -= 2000f;
                            Debug.Log("Income tax");
                        }
                        else
                        {
                            targetMoney -= 200f;
                            Debug.Log("Living expense");
                        }
                        break;
                    default:
                        break;
                }
                break;
            case Classes.upper:
                switch (targetRace)
                {
                    case Races.white:
                        if (targetMoney < 100000f)
                        {
                            targetMoney += 2000f;
                            Debug.Log("Welfare");
                        }
                        else if (targetMoney < 300000f)
                        {
                            targetMoney += 1500f;
                            Debug.Log("Holiday bonus");
                        }
                        else if (targetMoney > 500000f)
                        {
                            targetMoney += 3500f;
                            Debug.Log("Income tax");
                        }
                        else
                        {
                            targetMoney -= 200f;
                            Debug.Log("Living expense");
                        }
                        break;
                    case Races.black:
                        if (targetMoney < 100000f)
                        {
                            targetMoney += 2000f;
                            Debug.Log("Welfare");
                        }
                        else if (targetMoney < 300000f)
                        {
                            targetMoney += 1500f;
                            Debug.Log("Holiday bonus");
                        }
                        else if (targetMoney > 500000f)
                        {
                            targetMoney += 3500f;
                            Debug.Log("Income tax");
                        }
                        else
                        {
                            targetMoney -= 200f;
                            Debug.Log("Living expense");
                        }
                        break;
                    case Races.asian:
                        if (targetMoney < 100000f)
                        {
                            targetMoney += 2000f;
                            Debug.Log("Welfare");
                        }
                        else if (targetMoney < 300000f)
                        {
                            targetMoney += 1500f;
                            Debug.Log("Holiday bonus");
                        }
                        else if (targetMoney > 500000f)
                        {
                            targetMoney += 3500f;
                            Debug.Log("Income tax");
                        }
                        else
                        {
                            targetMoney -= 200f;
                            Debug.Log("Living expense");
                        }
                        break;
                    case Races.sAmer:
                        if (targetMoney < 100000f)
                        {
                            targetMoney += 2000f;
                            Debug.Log("Welfare");
                        }
                        else if (targetMoney < 300000f)
                        {
                            targetMoney += 1500f;
                            Debug.Log("Holiday bonus");
                        }
                        else if (targetMoney > 500000f)
                        {
                            targetMoney += 3500f;
                            Debug.Log("Income tax");
                        }
                        else
                        {
                            targetMoney -= 200f;
                            Debug.Log("Living expense");
                        }
                        break;
                    case Races.other:
                        if (targetMoney < 100000f)
                        {
                            targetMoney += 2000f;
                            Debug.Log("Welfare");
                        }
                        else if (targetMoney < 300000f)
                        {
                            targetMoney += 1500f;
                            Debug.Log("Holiday bonus");
                        }
                        else if (targetMoney > 500000f)
                        {
                            targetMoney += 3500f;
                            Debug.Log("Income tax");
                        }
                        else
                        {
                            targetMoney -= 200f;
                            Debug.Log("Living expense");
                        }
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }

        player.money = targetMoney;
    }

    private void OnBecameInvisible()
    {
        PlayerPrefs.SetInt("storyLevel", storyLevel += 1);
        eg.generate = true;
        Destroy(this.gameObject);
    }
}
