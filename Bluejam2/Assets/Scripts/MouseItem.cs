﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseItem : MonoBehaviour
{
    public static MouseItem Instance;

    public static InteractableItem item;

    public GameObject playerHand;

    // Use this for initialization
	void Start ()
	{
	    Instance = this;
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && item != null)
        {
            spawnPresent.Instance.newPresent();
            Destroy(item.gameObject);
            item = null;
        }
    }
    public bool PickupItem(InteractableItem newItem)
    {
        if (item == null)
        {
            item = newItem;
            item.transform.parent = playerHand.transform;
            item.transform.localPosition = Vector3.zero;
            item.transform.localRotation = Quaternion.identity;
            item.transform.localScale = Vector3.one/2f;
            return true;
        }
        if (item.transform.GetComponent<InteractablePresent>() != null)
        {
            item.name = "present";
        }
        return false;
    }

    public void UseItem()
    {
        if (item)
        {

            spawnPresent.Instance.newPresent();
            Destroy(item.gameObject);
        }
        item = null;
    }

}
