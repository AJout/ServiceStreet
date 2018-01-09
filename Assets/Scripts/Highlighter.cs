using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Highlighter : MonoBehaviour {
    [SerializeField]
    bool rotate = true;

    bool inRange = true;

    protected Transform headset;
    private GameObject defaultHighlight;
    private GameObject hoverHighlight;


    // Use this for initialization
    void Awake () {
        GetHeadset();
        defaultHighlight = transform.GetChild(0).gameObject;
        hoverHighlight = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (headset != null && rotate)
        {
            transform.rotation = Quaternion.LookRotation((headset.position - transform.position).normalized);
        }

        float distance = (headset.position - transform.position).magnitude;

        if (distance > 150 && inRange)
        {
            inRange = false;
            SetState(false, true);
        } else if (distance <= 150 && !inRange)
        {
            inRange = true;
            SetState(false, false);
        }
    }

    private void GetHeadset()
    {
        headset = VRTK_DeviceFinder.HeadsetTransform();
        if (headset == null)
        {
            Invoke("GetHeadset", 0.2f);
        }
    }

    public void SetState(bool hover, bool grabbed)
    {
        if (grabbed)
        {
            SetGrabbed();
        } else if (hover)
        {
            SetHover();
        } else
        {
            SetDefault();
        }
    }

    public void SetDefault()
    {
        defaultHighlight.SetActive(true);
        hoverHighlight.SetActive(false);
    }

    public void SetHover()
    {
        defaultHighlight.SetActive(false);
        hoverHighlight.SetActive(true);
    }

    public void SetGrabbed()
    {
        defaultHighlight.SetActive(false);
        hoverHighlight.SetActive(false);
    }
}
