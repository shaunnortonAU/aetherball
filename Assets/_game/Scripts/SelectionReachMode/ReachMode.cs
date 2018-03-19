using UnityEngine;

// Put this on the hand
public class ReachMode : IComponent
{
    public float closeRange;
    public float actualReachRange;
    public float projectedReachRange;

    public GameObject projectedHandPrefab;
    public GameObject projectedHandObject;

    public GameObject closePrefab;
    public GameObject actualReachPrefab;
    public GameObject projectedReachPrefab;

    public bool showRangePrefabs;

    public bool isInProjectedState;
    public float currentDistance;

    public GameObject shoulderObject;
}
