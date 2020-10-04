using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Objective))]
public class ObjectiveMakeGhostsHappy : MonoBehaviour
{
    public List<Ghost> ghosts;
    private int targetRemaining;

    Objective m_Objective;

    void Start()
    {
        m_Objective = GetComponent<Objective>();
        DebugUtility.HandleErrorIfNullGetComponent<Objective, ObjectiveMakeGhostsHappy>(m_Objective, this, gameObject);

        targetRemaining = ghosts.Count;

        foreach (var ghost in ghosts)
        {
            ghost.onHappy += OnGhostHappy;
        }
        if (string.IsNullOrEmpty(m_Objective.title))
            m_Objective.title = "Help all ghosts";

        if (string.IsNullOrEmpty(m_Objective.description))
            m_Objective.description = GetUpdatedCounterAmount();
    }

    void OnGhostHappy()
    {
        if (m_Objective.isCompleted) return;

        targetRemaining -= 1;

        if (targetRemaining == 0)
        {
            m_Objective.CompleteObjective(string.Empty, GetUpdatedCounterAmount(), "You made all ghosts happy");
        }
        else if (targetRemaining >= 1)
        {
            string notificationText = targetRemaining + " ghosts left";
            m_Objective.UpdateObjective(string.Empty, GetUpdatedCounterAmount(), notificationText);
        }
    }

    string GetUpdatedCounterAmount()
    {
        return (ghosts.Count - targetRemaining) + " / " + ghosts.Count;
    }

}
