using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance;

    public List<Task> tasks;

    public GameObject checkmarkPrefab;
    public GameObject crossPrefab;

    public Light directionalLight;

	// Use this for initialization
	void Start ()
	{
	    Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void finishTask(string taskName)
    {
        foreach (var task in tasks)
        {
            if (task.name.Equals(taskName))
            {
                GameObject go = Instantiate(checkmarkPrefab, task.transform);
                task.symbol = go;
                directionalLight.intensity += 0.35f;
            }
        }
    }

    public void failTask(string taskName)
    {
        foreach (var task in tasks)
        {
            if (task.name.Equals(taskName))
            {
                if (task.symbol!=null) {
                    Destroy(task.symbol);
                }
                GameObject go = Instantiate(crossPrefab, task.transform);
                task.symbol = go;
                directionalLight.intensity *= 0.5f;
            }
        }
    }
}
