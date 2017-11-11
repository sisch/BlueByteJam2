using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseItem : MonoBehaviour
{
    public static MouseItem Instance;

    public static InteractableItem item;

    // Use this for initialization
	void Start ()
	{
	    Instance = this;
	}

    public bool PickupItem(InteractableItem newItem)
    {
        if (item == null)
        {
            item = newItem;
            return true;
        }
        return false;
    }
}
