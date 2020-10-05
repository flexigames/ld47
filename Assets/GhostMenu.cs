using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostMenu : MonoBehaviour
{
    public Camera camera;
    public MeshRenderer ghostMesh;
    public Material ghostMaterialHappy;
    public Material ghostMaterialSad;

    private Outline outlineHover;

    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out hit))
        {
            if (outlineHover) outlineHover.OutlineWidth = 0;
            ghostMesh.material = ghostMaterialSad;
            return;
        }
        
        Transform objectHit = hit.transform;
        var objectName = objectHit.gameObject.name;

        if (objectName != "PlayButton")
        {
            if (outlineHover) outlineHover.OutlineWidth = 0;
            ghostMesh.material = ghostMaterialSad;
            return;
        }

        var outline = objectHit.gameObject.GetComponent<Outline>();
        outline.OutlineWidth = 9;
        outlineHover = outline;

        ghostMesh.material = ghostMaterialHappy;
        
        
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("MainScene");
        }       
    }
}
