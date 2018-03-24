using UnityEngine;

// Put this on the hand
public class ReachMode : IComponent
{
    public GameObject projectedHandObject;
    public GameObject shoulderObject;

    public float closeRange;
    public float actualReachRange;
    public float projectedReachRange;
    
    public bool isInProjectedState;
    public float currentDistance;

}
