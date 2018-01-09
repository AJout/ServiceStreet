using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitRouteNPC : MonoBehaviour {
    Vector3 target;

    private void Update()
    {
        if((transform.position - target).magnitude < 1)
        {
            Invoke("Kill", 2f);
        }
    }

    public void SetTarget(Vector3 target)
    {
        this.target = target;
    }

    private void Kill()
    {
        Destroy(this.gameObject);
    }
}
