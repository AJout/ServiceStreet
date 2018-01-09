using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class InfoObjectLineHandler : MonoBehaviour {
    LineRenderer lineRenderer;
    GameObject hand;
    [SerializeField]
    GameObject startPoint;

	void Start () {
        lineRenderer = GetComponent<LineRenderer>();
        hand = VRTK_DeviceFinder.GetControllerRightHand();
    }

    void Update () {
        lineRenderer.SetPosition(0, startPoint.transform.position);
        if(hand == null) hand = VRTK_DeviceFinder.GetControllerRightHand();
        if (Vector3.Distance(hand.transform.position, startPoint.transform.position) < 5) lineRenderer.SetPosition(1, hand.transform.position);
        else lineRenderer.SetPosition(1, startPoint.transform.position);
        
    }
}
