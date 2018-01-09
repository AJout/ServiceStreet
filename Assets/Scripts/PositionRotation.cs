using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PositionRotation : MonoBehaviour {
    [SerializeField]
    VRTK_BasicTeleport basicTeleport;

    protected Transform playArea;
    protected Transform headset;

    [SerializeField]
    PlayerTracker playerTracker;

    [SerializeField]
    Vector3 rotation;


    // Use this for initialization
    void OnEnable () {
        GetPlayAreaAndHeadset();
        Debug.Log(playArea);
        GetComponent<VRTK_ControllerEvents>().ButtonOnePressed += new ControllerInteractionEventHandler(ButtonOnePressed);
    }

    // Update is called once per frame
    void Update () {
		
	}

    void ButtonOnePressed(object sender, ControllerInteractionEventArgs e)
    {
        Rotate();
    }

    private void Rotate()
    {
        if (playArea != null && headset != null)
        {
            Debug.Log(playArea.gameObject);
            basicTeleport.Teleport(playerTracker.transform, playerTracker.transform.position, playArea.rotation * Quaternion.Euler(rotation));  
        }
    }

    private void GetPlayAreaAndHeadset()
    {
        playArea = VRTK_DeviceFinder.PlayAreaTransform();
        headset = VRTK_DeviceFinder.HeadsetTransform();
        if (playArea == null && headset == null)
        {
            Invoke("GetPlayAreaAndHeadset", 0.2f);
        }
    }
}
