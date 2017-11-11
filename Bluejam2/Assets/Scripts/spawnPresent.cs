using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPresent : MonoBehaviour
{
    public static spawnPresent Instance;
    public GameObject presentPrefab;
	// Use this for initialization
	void Start ()
	{
	    Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void newPresent()
    {
        GameObject go = Instantiate(presentPrefab, Vector3.zero, Quaternion.identity, transform);
        go.transform.localPosition = Vector3.zero;
    }
}
