using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPG_QuestObject : InteractParent {

    public string QuestName;
    public int questValue;

    private bool interacted = false;

    RPG_Quest quest;

    private void Start()
    {
        quest = GameObject.Find(QuestName).GetComponent<RPG_Quest>();
    }

    public override void Interact()
    {
        if (!interacted)
        {
            int checkValue = (questValue == 0) ? 0 : questValue;

            if (quest.getProgress() == checkValue)
            {
                quest.checkProgress();
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                interacted = true;
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                StartCoroutine(ResetColor());
            }
        }
    }

    IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(1f);

        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
