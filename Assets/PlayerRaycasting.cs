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
            Outline outlineOld = lastSeen.GetComponent(typeof(Outline)) as Outline;
            if (outlineOld) outlineOld.OutlineWidth = 0;
        }

        if (hasHit)
        {
            var objectSeen = whatIHit.collider.gameObject;

            lastSeen = objectSeen;

            Outline outline = objectSeen.GetComponent(typeof(Outline)) as Outline;
            if (outline)
            {
                outline.OutlineWidth = 7;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(objectSeen);
            }
        }
    }
}
