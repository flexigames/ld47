using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankTarget : Target
{
    [SerializeField] public Material finalMaterial;

    public override void OnInteract()
    {
        Debug.Log("Interacted with the plank!");
        var collider = GetComponent<Collider>();
        collider.isTrigger = false;

        GetComponent<MeshRenderer>().material = finalMaterial;
        
        this.DisableOutline();
        
        var player = GameObject.FindWithTag("Player");
        var carrying = player.GetComponent<Carrying>();
        carrying.itemType = null;
        Destroy(carrying.itemGameObject);

        resolved = true;

        Destroy(this);
    }
    
    public override bool isActive()
    {
        var player = GameObject.FindWithTag("Player");
        if (!player) return false;
        var carrying = player.GetComponent<Carrying>();
        return carrying.itemType == "Plank";
    }
}
