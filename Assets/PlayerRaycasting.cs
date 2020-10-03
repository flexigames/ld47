using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycasting : MonoBehaviour
{
    public float distanceToInteract;
    private RaycastHit whatIHit;
    private GameObject lastSeen;
    void Start()
    {
        
    }
    
    void Update()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToInteract, Color.magenta);

        var hasHit = Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit, distanceToInteract);
        
        
        if (lastSeen && (!hasHit || (lastSeen != whatIHit.collider.gameObject)))
        {
            lastSeen.GetComponent<Interactable>()?.DisableOutline();
        }

        if (hasHit)
        {
            var objectSeen = whatIHit.collider.gameObject;

            var interactionTarget = objectSeen.GetComponent<Interactable>();
            if (!interactionTarget) return;

            lastSeen = objectSeen;
            
            interactionTarget.EnableOutline();
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactionTarget.OnInteract();
            }
        }
    }
}
