using UnityEngine;

public class NodeVectorVisualisation : ISystem
{
    public LineRenderer cLineRenderer;
    public NodeVectorVisual cNodeVectorVisual;
    public NodeVector cNodeVector;

    private void Start () {
        Visualise();
    }

    private void Update()
    {
        if (cNodeVector.isUpdated)
            Visualise();
    }

    private void Visualise()
    {
        NodeVector cNodeVector = gameObject.GetComponent<NodeVector>();

        cLineRenderer.SetPositions(new Vector3[] { transform.position, transform.position + cNodeVector.forceVector });

        float percentageOfMaximum = cNodeVector.forceVector.sqrMagnitude / cNodeVector.maxSqrMagnitude;

        if (percentageOfMaximum > cNodeVectorVisual.strongThreshold)
        {
            cLineRenderer.material = cNodeVectorVisual.strongMaterial;
        }
        if (percentageOfMaximum <= cNodeVectorVisual.strongThreshold)
        {
            cLineRenderer.material = cNodeVectorVisual.mediumMaterial;
        }
        if (percentageOfMaximum <= cNodeVectorVisual.weakThreshold)
        {
            cLineRenderer.material = cNodeVectorVisual.weakMaterial;
        }
    }
}
