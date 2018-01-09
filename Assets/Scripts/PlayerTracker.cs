using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PlayerTracker : MonoBehaviour {
    protected Transform playArea;
    protected Transform headset;

    // Use this for initialization
    void Awake () {
        playArea = VRTK_DeviceFinder.PlayAreaTransform();
        headset = VRTK_DeviceFinder.HeadsetTransform();
    }
	
	// Update is called once per frame
	void Update () {
        if (playArea == null)
        {
            playArea = VRTK_DeviceFinder.PlayAreaTransform();
            headset = VRTK_DeviceFinder.HeadsetTransform();
        } else if (playArea != null && headset != null)
        {
            transform.position = new Vector3(headset.position.x, playArea.position.y, headset.position.z);
            transform.rotation = Quaternion.Euler(0, headset.eulerAngles.y, 0);
        }
    }
}
