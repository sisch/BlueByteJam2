using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableCat : InteractableItem {
    public override void Click()
    {
        Debug.Log("Meow");
    }
}
