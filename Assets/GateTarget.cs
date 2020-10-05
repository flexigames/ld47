using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTarget : Target
{
    public string RequiredItem = "Key";
    public bool deleteCarrying = true;

    public override void OnInteract()
    {
        this.DisableOutline();
        
        var player = GameObject.FindWithTag("Player");
        var carrying = player.GetComponent<Carrying>();
        if (deleteCarrying)
        {
            carrying.itemType = null;
            Destroy(carrying.itemGameObject);
        }

        resolved = true;
        
        Destroy(gameObject);
        Destroy(this);
    }
    
    public override bool isActive()
    {
        var player = GameObject.FindWithTag("Player");
        if (!player) return false;
        var carrying = player.GetComponent<Carrying>();
        return carrying.itemType == RequiredItem;
    }
}
