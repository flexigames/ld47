using System.Collections.Generic;
using UnityEngine;

public class ObjectiveHUDManger : MonoBehaviour
{
    [Tooltip("UI panel containing the layoutGroup for displaying objectives")]
    public RectTransform objectivePanel;



    public void RegisterObjective(Objective objective)
    {
        objective.onUpdateObjective += OnUpdateObjective;


    }

    public void UnregisterObjective(Objective objective)
    {
        objective.onUpdateObjective -= OnUpdateObjective;
    }

    void OnUpdateObjective(UnityActionUpdateObjective updateObjective)
    {
    }
}
