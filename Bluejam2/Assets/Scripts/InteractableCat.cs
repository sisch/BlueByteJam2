using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableCat : InteractableItem
{
    private IEnumerator action;

    void Start()
    {
        action = catResponse();
    }

    public override void Click()
    {
        action.MoveNext();
    }

    IEnumerator catResponse()
    {
        int timesClicked = 1;
        Debug.Log("Meow");
        // Play Sound
        yield return null;
        while (timesClicked < 7)
        {
            timesClicked++;
            // Play Sound
            Debug.Log("Meow"+timesClicked);
            yield return null;
        }
        // Play awful sound
        // Tilt cat
        transform.GetComponentInChildren<MeshRenderer>().material.color = Color.black;
        //transform.DORotate();
    }
}
