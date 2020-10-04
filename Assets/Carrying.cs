using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Configuration;
using UnityEngine;

public class Carrying : MonoBehaviour
{
    public string itemType;
    public Transform socket;
    public GameObject itemGameObject;

    private bool freezeDrop = false; 

    public void Drop()
    {
        if (!itemGameObject) return;
        itemType = "";
        socket.DetachChildren();
        itemGameObject.transform.position = transform.position;
        itemGameObject = null;
    }

    public void Pickup(GameObject item, string type)
    {
        Drop();
        itemType = type;
        
        item.transform.parent = socket;
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
        item.layer = 10;
        
        itemGameObject = gameObject;

        freezeDrop = true;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !freezeDrop) Drop();
        freezeDrop = false;
    }
}
