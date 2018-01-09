using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToggleTextInteractable : MonoBehaviour {

    private bool expand = false;
    TextMeshPro tmpro;

    private void Start()
    {
        tmpro = GetComponentInChildren<TextMeshPro>();
    }

    // Update is called once per frame
    void Update () {
        float newScale = 0f;
        if (expand) newScale = transform.GetChild(0).localScale.x + 1f * Time.deltaTime;
        else newScale = transform.GetChild(0).localScale.x - 1f * Time.deltaTime;
        newScale = Mathf.Clamp(newScale, 0f, 1f);
        transform.GetChild(0).localScale = new Vector3(newScale, newScale, newScale);
	}

    public void SetExpand(bool value)
    {
        expand = value;
    }
}
