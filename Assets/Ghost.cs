using System.Collections;
using System.Collections.Generic;
using PathCreation;
using PathCreation.Examples;
using UnityEngine;
using UnityEngine.Events;

public class Ghost : MonoBehaviour
{

    public List<Target> conditions;
    public PathCreator sadPath;
    public PathCreator happyPath;
    private bool madeHappy = false;

    public UnityAction onHappy;
    
    void Update()
    {
        var allResolved = true;
        foreach (var condition in conditions)
        {
            allResolved = condition.resolved && allResolved;
        }

        if (!allResolved) return;
            
        var pathFollower = GetComponent<PathFollower>();
        
        if (!madeHappy && pathFollower.distanceTravelled % sadPath.path.length < 0.5f)
        {
            madeHappy = true;

            onHappy?.Invoke();
   
            pathFollower.pathCreator = happyPath;
            pathFollower.endOfPathInstruction = EndOfPathInstruction.Stop;
            pathFollower.distanceTravelled = 0f;
            Debug.Log("All resolved");
        }
    }
}
