using UnityEngine;

// Put this on the hand
public class ReachMode : IComponent
{
    public float closeRange;
    public float actualReachRange;
    public float projectedReachRange;

    public GameObject projectedHandPrefab;

    public GameObject closePrefab;
    public GameObject actualReachPrefab;
    public GameObject projectedReachPrefab;

    public bool showRangePrefabs;
}
