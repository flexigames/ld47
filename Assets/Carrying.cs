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

        RaycastHit whatIHit;
        var hasHit = Physics.Raycast(itemGameObject.transform.position, -transform.up, out whatIHit);
        if (hasHit)
        {
            itemGameObject.transform.position = whatIHit.point;
        }
        
        itemType = "";
        socket.DetachChildren();

        setLayer(itemGameObject, 0);

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
        setLayer(item, layerIndex);
        
        itemGameObject = item;

        freezeDrop = true;
    }

    private static void setLayer(GameObject go, int layerIndex)
    {
        go.layer = layerIndex;
        foreach (Transform t in go.GetComponentsInChildren<Transform>(true))
        {
            t.gameObject.layer = layerIndex;
        }

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !freezeDrop) Drop();
        freezeDrop = false;
    }
}
