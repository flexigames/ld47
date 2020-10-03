using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycasting : MonoBehaviour
{
    public float distanceToInteract;
    void Start()
    {
        
    }
    
    void Update()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToInteract, Color.magenta);
    }
}
