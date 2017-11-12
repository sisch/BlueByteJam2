using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fadeSequence : MonoBehaviour
{
    [Range(0.001f,1)]
    public float fadeValue;
    public List<CanvasGroup> elements;
	// Use this for initialization
	IEnumerator Start ()
	{
	    int i = 0;
	    yield return new WaitForEndOfFrame();
	    while (i < elements.Count)
	    {
	        while (elements[i].alpha < 0.95f)
	        {
	            elements[i].alpha += fadeValue;
                yield return null;
	        }
	        elements[i].alpha = 1f;
	        i++;
	        yield return null;
	    }

    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Jump"))
	    {
	        SceneManager.LoadScene(1);
	    }	
	}
}
