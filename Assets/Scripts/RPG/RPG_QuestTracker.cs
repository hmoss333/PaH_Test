using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPG_QuestTracker : MonoBehaviour {

    public Dictionary<string, int> currentQuests;

	// Use this for initialization
	void Start () {
        currentQuests = new Dictionary<string, int>();
    }

    public void AddQuest(string questName, int questProgress)
    {
        if (!currentQuests.ContainsKey(questName))
        {
            currentQuests.Add(questName, questProgress);
        }
        else
        {
            UpdateQuest(questName, questProgress);
        }

        Debug.Log(questName + ": " + currentQuests[questName]);
    }

    public void UpdateQuest(string questName, int questProgress)
    {
        if (currentQuests.ContainsKey(questName))
        {
            currentQuests[questName] = questProgress;
        }

        Debug.Log(questName + ": " + currentQuests[questName]);
    }
}
