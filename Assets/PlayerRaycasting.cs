using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycasting : MonoBehaviour
{
    public float distanceToInteract;
    private RaycastHit whatIHit;
    void Start()
    {
        
    }
    
    void Update()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToInteract, Color.magenta);

        var hasHit = Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit, distanceToInteract);

        if (hasHit && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("I touched " + whatIHit.collider.gameObject.name);
            Destroy(whatIHit.collider.gameObject);
        }
    }
}
