using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class InteractionBase : MonoBehaviour {
    protected VRTK_InteractableObject interactableObject;

    // Use this for initialization
    void Awake () {
        interactableObject = GetComponent<VRTK_InteractableObject>();
        interactableObject.InteractableObjectUsed += new InteractableObjectEventHandler(Used);
        interactableObject.InteractableObjectGrabbed += new InteractableObjectEventHandler(Grabbed);
    }

    

    public virtual void Used(object sender, InteractableObjectEventArgs e)
    {

    }

    public virtual void Grabbed(object sender, InteractableObjectEventArgs e)
    {

    }
}
