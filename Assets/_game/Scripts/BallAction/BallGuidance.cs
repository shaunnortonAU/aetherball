using UnityEngine;

public class BallGuidance : ISystem {

    public Inertia cBallInertia;
    public BallGuided cBallGuided;

    void Update ()
    {
        // Get the guiding hand entity
        GameObject guidingHand = cBallGuided.guidingHand;
        BallGuider cBallGuider = guidingHand.GetComponent<BallGuider>();

        if (guidingHand)
        {
            // Method 1: Guiding relative to position of hand at start of guide.
            // Get the relative change in position
            Vector3 deltaPosition = guidingHand.transform.position - cBallGuider.startPosition;

            Vector3 guidingVector = new Vector3(
                Mathf.Max(cBallGuided.guidingVelocityNudge, cBallInertia.inertia.x) * cBallGuided.guidingVelocityMultiplier * Mathf.Clamp(deltaPosition.x, -cBallGuider.maxGuidingSpan, cBallGuider.maxGuidingSpan),
                Mathf.Max(cBallGuided.guidingVelocityNudge, cBallInertia.inertia.y) * cBallGuided.guidingVelocityMultiplier * Mathf.Clamp(deltaPosition.y, -cBallGuider.maxGuidingSpan, cBallGuider.maxGuidingSpan),
                Mathf.Max(cBallGuided.guidingVelocityNudge, cBallInertia.inertia.z) * cBallGuided.guidingVelocityMultiplier * Mathf.Clamp(deltaPosition.z, -cBallGuider.maxGuidingSpan, cBallGuider.maxGuidingSpan)
                );
            cBallInertia.inertia = guidingVector;
        }
    }
}
