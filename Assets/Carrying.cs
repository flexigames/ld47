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

    private int layerIndex = 10;

    public void Drop()
    {
        if (!itemGameObject) return;
        itemType = "";
        socket.DetachChildren();

        var collider = itemGameObject.GetComponent<Collider>();
        collider.enabled = true;
        
        itemGameObject = null;
    }

    public void Pickup(GameObject item, string type)
    {
        Drop();
        itemType = type;

        var collider = item.GetComponent<Collider>();
        collider.enabled = false;

        item.transform.parent = socket;
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
        item.layer = layerIndex;
        foreach (Transform t in gameObject.GetComponentsInChildren<Transform>(true))
        {
            t.gameObject.layer = layerIndex;
        }
        
        itemGameObject = item;

        freezeDrop = true;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !freezeDrop) Drop();
        freezeDrop = false;
    }
}
