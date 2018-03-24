using UnityEngine;

public class InertiaPoll : IComponent
{
    public float pollInterval;

    [HideInInspector]
    public float lastPollTime;
    [HideInInspector]
    public Vector3 handStartPosition;
}
