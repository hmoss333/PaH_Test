using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGenerator : MonoBehaviour {

    public enum Races { white, black, asian, sAmer, other }
    public enum Classes { lower, middle, upper }

    PlayerCharacter player;

    public List<EventObject> events;
    EventObject currentEvent;

    public EventObject[] eventPool;

    public int currentStoryLevel = 0;

    public bool generate;

    // Use this for initialization
    void Start () {
        player = GameObject.FindObjectOfType<PlayerCharacter>();

        currentStoryLevel = 0;
        PlayerPrefs.SetInt("storyLevel", currentStoryLevel);
        SetScenarios();

        generate = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (generate)
        {
            currentStoryLevel = PlayerPrefs.GetInt("storyLevel");
            if (currentStoryLevel > 2)
                currentStoryLevel = 2;

            GenerateScenarios(currentStoryLevel);
            generate = false;
        }
    }

    void SetScenarios()
    {
        Races targetRace = (Races)player.race;
        Classes targetClass = (Classes)player.classes;

        foreach (EventObject objects in eventPool)
        {
            if ((Classes)objects.classes == targetClass && (Races)objects.race == targetRace)
            {
                if (!events.Contains(objects))
                    events.Add(objects);
            }
        }

        Debug.Log("Race: " + targetRace);
        Debug.Log("Class: " + targetClass);
        Debug.Log("Story Level: " + currentStoryLevel);
    }

    void GenerateScenarios (int storyLevel)
    {
        foreach (EventObject objects in events)
        {
            if (objects.storyLevel == storyLevel)
                currentEvent = Instantiate(objects);
        }

        Mathf.PerlinNoise(10f, 10f);
    }
}
