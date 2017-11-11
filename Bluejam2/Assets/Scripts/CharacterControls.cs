using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
class CharacterControls : MonoBehaviour
{
    [SerializeField] private float interactionDistance;
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
        GameObject hitObject = hit.transform.gameObject;
        InteractableItem item = hitObject.GetComponent<InteractableItem>();
        if (item != null)
        {
            while (agent.remainingDistance > interactionDistance)
            {
                yield return null;
            }
            agent.isStopped = true;
            item.Click();
        }
        yield return null;
    }
}
