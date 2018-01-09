using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ExitRouteSpawner : MonoBehaviour {
    [SerializeField]
    GameObject[] exitRoutes;
    [SerializeField]
    GameObject exitRouteNPC;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")){
            SpawnExitNPCs();
        }
	}

    public void SpawnExitNPCs()
    {
        Vector3 closestExitRoute = new Vector3(10000,10000,10000);
        foreach (GameObject exitRoute in exitRoutes)
        {
            if(Vector3.Distance(exitRoute.transform.position, transform.position) < Vector3.Distance(closestExitRoute, transform.position))
            {
                closestExitRoute = exitRoute.transform.position;
            }
            
        }
        GameObject newrouteNPC = Instantiate(exitRouteNPC, transform.position, transform.rotation);
        newrouteNPC.GetComponent<NavMeshAgent>().enabled = true;
        newrouteNPC.GetComponent<NavMeshAgent>().SetDestination(closestExitRoute);
        newrouteNPC.GetComponent<ExitRouteNPC>().SetTarget(closestExitRoute);
    }

}
