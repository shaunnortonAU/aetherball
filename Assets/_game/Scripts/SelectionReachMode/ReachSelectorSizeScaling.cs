using UnityEngine;

public class ReachSelectorSizeScaling : ISystem
{
    public ReachSelector cReachSelector;
    public SphereCollider cSphereCollider;
    
    private ReachMode cReachMode;

    // Use this for initialization
    void Start ()
    {
        cReachMode = cReachSelector.belongsToReachObject.GetComponent<ReachMode>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (cReachMode.isInProjectedState)
        {
            // Calculate distance as proportion of range
            // This provides a minimum of 0.1 and maximum of 0.75
            // This is not perfect. IE the minimum occurs at 0 distance (the player's body) but I'll keep it as-is for now

            float scaleMultiplier = 0.2f + 0.8f * cReachMode.currentDistance / cReachMode.projectedReachRange;
            cSphereCollider.radius = scaleMultiplier;
        }
	}
}
