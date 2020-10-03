using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankTarget : Interactable
{
    [SerializeField] public Material finalMaterial;
    
    public override void OnInteract()
    {
        Debug.Log("Interacted with the plank!");
        var collider = GetComponent<Collider>();
        collider.isTrigger = false;

        GetComponent<MeshRenderer>().material = finalMaterial;
        
        this.DisableOutline();

        Destroy(this);
    }
}
