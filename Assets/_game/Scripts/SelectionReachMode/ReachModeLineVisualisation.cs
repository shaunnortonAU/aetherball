using UnityEngine;

public class ReachModeLineVisualisation : ISystem
{
    public ReachModeLineVisual cReachModeLineVisual;
    public ReachMode cReachMode;
    private LineRenderer cLineRenderer;

    private void Start()
    {
        cLineRenderer = cReachModeLineVisual.cLineRenderer;
        cLineRenderer.enabled = false;
    }
    private void Update()
    {
        if (cReachMode.isInProjectedState)
        {
            cLineRenderer.enabled = true;
            cLineRenderer.SetPositions(new Vector3[]{ gameObject.transform.position, cReachMode.projectedHandObject.transform.position});
        }
        else
        {
            cLineRenderer.enabled = false;
        }

    }
}
