using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactable
{
    public string itemType;
    public Transform carryTransform;

    public override void OnInteract()
    {
        Debug.Log("Picked up item " + itemType);
        var player = GameObject.FindWithTag("Player");
        if (!player) return;
        var carrying = player.GetComponent<Carrying>();
        carrying.Pickup(gameObject, itemType);
        if (carryTransform)
        {
            gameObject.transform.localPosition = carryTransform.localPosition;
            gameObject.transform.localRotation = carryTransform.localRotation;
        }
        else
        {
            gameObject.transform.localPosition = Vector3.zero;
            gameObject.transform.localRotation = Quaternion.identity;
        }
    }
}
