using UnityEngine;

public class NodeVector : IComponent
{
    public Vector3 forceVector;
    public float maxSqrMagnitude;
    public bool additive;
    public bool isUpdated;

    // Debugging private void Update() { Debug.Log(forceVector.ToString("F4"));  }
}
