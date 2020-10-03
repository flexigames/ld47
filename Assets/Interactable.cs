using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void OnInteract()
    {
        Debug.Log("Interacted with a random Interactable!");
    }

    public virtual bool isActive()
    {
        return true;
    }

    public void EnableOutline()
    {
        var outline = GetComponent<Outline>();
        if (outline) outline.OutlineWidth = 7;
    }
    
    public void DisableOutline()
    {
        var outline = GetComponent<Outline>();
        if (outline) outline.OutlineWidth = 0;
    }
}
