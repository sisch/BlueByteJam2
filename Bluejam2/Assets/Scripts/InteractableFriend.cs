using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InteractableFriend : InteractableItem
{
    private IEnumerator receiveGift;
	// Use this for initialization
	void Start ()
	{
	    receiveGift = gift();
	}
	
	// Update is called once per frame
	void Update () {
    }

    public override void Click()
    {
        receiveGift.MoveNext();
        if (MouseItem.item && MouseItem.item.gameObject.name.Equals("present"))
        {
            // Receive present
            MouseItem.item.transform.SetParent(transform);
            MouseItem.item = null;
            spawnPresent.Instance.newPresent();
        }
    }

    IEnumerator gift()
    {
        int timesClicked = 0;
        while (timesClicked < 4)
        {
            if (MouseItem.item == null)
            {
                yield return null;
                continue;
               
            }

            timesClicked++;
            if (timesClicked == 2)
            {
                TaskManager.Instance.finishTask("Friend");
            }
            // Play Sound
            Debug.Log("Thank you" + timesClicked);
            yield return null;
        }
        // Play awful sound
        transform.GetComponentInChildren<MeshRenderer>().material.color = Color.black;
        Rigidbody r = gameObject.AddComponent<Rigidbody>();
        r.angularVelocity = transform.right * -15f;
        TaskManager.Instance.failTask("Friend");
        GetComponent<NavMeshAgent>().enabled = false;
    }
}
