using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopTarget : Interactable
{
    public override void OnInteract()
    {
        var animator = GetComponent<Animator>();
        animator.enabled = true;
        
        var player = GameObject.FindWithTag("Player");
        var carrying = player.GetComponent<Carrying>();
        carrying.itemType = null;
        Destroy(carrying.itemGameObject);
        
        Destroy(this);
    }
    
    public override bool isActive()
    {
        var player = GameObject.FindWithTag("Player");
        if (!player) return false;
        var carrying = player.GetComponent<Carrying>();
        
        return carrying.itemType == "Axe";
    }
}
