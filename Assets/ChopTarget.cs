﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopTarget : Target
{
    public override void OnInteract()
    {
        this.DisableOutline();

        var animator = GetComponent<Animator>();
        animator.enabled = true;
        
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
        
        return carrying.itemType == "Axe";
    }
}
