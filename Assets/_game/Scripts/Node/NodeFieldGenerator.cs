using UnityEngine;

public class NodeFieldGenerator : IComponent
{
    public Vector3 gridSize;
    public GameObject[,,] gridOfGameObjects;
    public float gridSpacing;
    public GameObject nodePrefab;
}
