using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPG_Quest : MonoBehaviour {

    public string questName = "Quest1";
    public int currentProgress;

    public GameObject[] questObjects;

    RPG_QuestTracker questTracker;

    // Use this for initialization
    void Start () {
        questTracker = GameObject.FindObjectOfType<RPG_QuestTracker>();
    }

    public void checkProgress ()
    {
        if (!questTracker.currentQuests.ContainsKey(questName))
        {
            questTracker.AddQuest(questName, currentProgress);
            currentProgress++;

            Debug.Log("Added new quest: " + questName + "; " + currentProgress);
        }
        else if (currentProgress < questObjects.Length - 1)
        {
            currentProgress++;
            questTracker.UpdateQuest(questName, currentProgress);

            Debug.Log("Updated quest: " + questName + ": " + currentProgress);
        }

        //switch (currentProgress)
        //{
        //    case 0:
        //        questTracker.AddQuest(questName, currentProgress);
        //        currentProgress++;
        //        break;
        //    case 1:
        //        currentProgress++;
        //        questTracker.UpdateQuest(questName, currentProgress);
        //        break;
        //    case 2:
        //        currentProgress++;
        //        questTracker.UpdateQuest(questName, currentProgress);
        //        break;
        //    case 3:
        //        currentProgress++;
        //        questTracker.UpdateQuest(questName, currentProgress);
        //        break;
        //    default:
        //        //currentProgress = 0;
        //        break;
        //}

        Debug.Log("Current Progress: " + currentProgress);
    }

    public int getProgress ()
    {
        return currentProgress;
    }
}
