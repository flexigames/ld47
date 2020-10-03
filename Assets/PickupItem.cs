using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactable
{
    public string itemType;
    
    public override void OnInteract()
    {
        Debug.Log("Picked up item " + itemType);
        var player = GameObject.FindWithTag("Player");
        if (!player) return;
        var carrying = player.GetComponent<Carrying>();
        carrying.itemType = itemType;
        Destroy(gameObject);
    }
}
