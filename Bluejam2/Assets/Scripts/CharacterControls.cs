using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
class CharacterControls : MonoBehaviour
{
    [SerializeField] private float interactionDistance;
    [SerializeField] private float arrivalDistance;
    private NavMeshAgent agent;

    // Use this for initialization
	void Start ()
	{

	    agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    ProcessInput();

	}

    void ProcessInput()
    {
        if (Input.mousePresent)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StopAllCoroutines();
                agent.isStopped = false;
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    agent.destination = hit.point;
                    StartCoroutine("Interact", hit);
                }
                
            }
        }
    }

    private IEnumerator Interact(RaycastHit hit)
    {
        yield return new WaitForEndOfFrame();
        GameObject hitObject = hit.transform.gameObject;
        InteractableItem item = hitObject.GetComponent<InteractableItem>();
        if (item != null)
        {
            float distance = hitObject.name.Equals("cat") ? 1.5f : interactionDistance;
            while (Vector3.Distance(hit.point,transform.position) > distance)
            {
                Debug.Log("Too far away, "+ hitObject.name);
                yield return null;
            }
            agent.isStopped = true;
            while (agent.velocity.magnitude > arrivalDistance)
            {
                Debug.Log("Too much velocity, " + hitObject.name);
                yield return null;
            }
            item.Click();
        }
        yield return null;
    }
}
