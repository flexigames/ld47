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
        gameObject.transform.parent = carrying.socket;
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.transform.localRotation = Quaternion.identity;
        carrying.itemGameObject = gameObject;
    }
}
