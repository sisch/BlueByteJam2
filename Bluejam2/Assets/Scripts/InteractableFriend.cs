using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableFriend : InteractableItem {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Click()
    {
        Debug.Log("Friend");
        if (MouseItem.item.gameObject.name.Equals("present"))
        {
            // Receive present
            Debug.Log("Thank you");
            MouseItem.Instance.UseItem();
        }
    }
}
