using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostMenu : MonoBehaviour
{
    public Camera camera;

    private Outline outlineHover;
    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out hit))
        {
            if (outlineHover) outlineHover.OutlineWidth = 0;
            return;
        }
        
        Transform objectHit = hit.transform;
        var objectName = objectHit.gameObject.name;

        if (objectName != "PlayButton")
        {
            if (outlineHover) outlineHover.OutlineWidth = 0;
            return;
        }

        var outline = objectHit.gameObject.GetComponent<Outline>();
        outline.OutlineWidth = 9;
        outlineHover = outline;
        
        
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("MainScene");
        }       
    }
}
