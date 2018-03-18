using UnityEngine;

public class NodeVectorVisual : ISystem
{
    public float strongThreshold = 0.70f;
    public float weakThreshold = 0.30f;
    public Material strongMaterial;
    public Material mediumMaterial;
    public Material weakMaterial;
}
