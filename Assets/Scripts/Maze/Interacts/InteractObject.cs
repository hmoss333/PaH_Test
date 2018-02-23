using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : InteractParent {


    public override void Interact()
    {
        base.Interact();
        //DisplayText();
        player.itemCount++;
        Destroy(this.gameObject);
    }

    void DisplayText()
    {
        //Debug.Log("Displaying Text: " + currentText);

        //uiBox.SetActive(true);
        //textBubble.text = text[currentText];
        //StartCoroutine(WaitForInput());
    }

    IEnumerator WaitForInput()
    {
        yield return new WaitForSeconds(0f);
        Debug.Log("Waiting for Input...");

        //while (waitForInput)
        //    yield return null;

        //if (currentText < text.Length - 1) //If there are still text options to go through
        //{
        //    currentText++;
        //    waitForInput = false;
        //    DisplayText();
        //}
        //else //If the player has reached the end of the text options
        //{
        //    currentText = 0;
        //    uiBox.SetActive(false);
        //    player.interacting = false;
        //}
    }
}
