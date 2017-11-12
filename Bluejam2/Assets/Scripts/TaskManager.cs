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

    private int failedTasks;
    private int completedTasks;

    public GameObject GameOverOverlay;
    public GameObject HappyOverlay;
	// Use this for initialization
	void Start ()
	{
	    Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	    if (failedTasks == 2)
	    {
	        GameOver();
	        failedTasks++;
	    }
	    if (completedTasks == 2)
	    {
	        showHappy();
	        completedTasks = 0;
	    }
	}

    public void finishTask(string taskName)
    {
        resetOverlays();
        foreach (var task in tasks)
        {
            if (task.name.Equals(taskName))
            {
                GameObject go = Instantiate(checkmarkPrefab, task.transform);
                task.symbol = go;
                directionalLight.intensity += 0.35f;
            }
        }
        completedTasks++;
    }

    public void failTask(string taskName)
    {
        resetOverlays();
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
        failedTasks++;
        completedTasks--;
    }

    void GameOver()
    {
        GameOverOverlay.GetComponent<CanvasGroup>().alpha = 1;
    }

    void showHappy()
    {
        HappyOverlay.GetComponent<CanvasGroup>().alpha = 1;
    }

    void resetOverlays()
    {
        HappyOverlay.GetComponent<CanvasGroup>().alpha = 0;
        GameOverOverlay.GetComponent<CanvasGroup>().alpha = 0;
    }
}
