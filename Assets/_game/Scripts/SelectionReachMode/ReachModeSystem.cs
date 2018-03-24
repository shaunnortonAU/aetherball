using UnityEngine;

public class ReachModeSystem : ISystem
{
    public ReachMode cReachMode;
    public InputHand cInputHand;

    private Vector3 projDestination, pastFollowerPosition, pastTargetPosition;
    private ReachHand cReachHand;

    private void Start()
    {
        cReachHand = cReachMode.projectedHandObject.GetComponent<ReachHand>();
    }

    private void Update()
    {
        
        Vector3 handDisplacement = cInputHand.gameObject.transform.position - cReachMode.shoulderObject.transform.position;

        float handMag = handDisplacement.magnitude;

        // Scale this up a bit to allow for rounding in the mapped position
        if (handMag > cReachMode.closeRange)
        {
            // Set the Reach Mode state
            cReachMode.isInProjectedState = true;

            // Show the model
            cReachHand.model.SetActive(true);

            // Calculate the projected magnitude based on actual hand magnitude in the close>actual range.
            float projMag = Mathf.Min(cReachMode.projectedReachRange, MapRange(cReachMode.closeRange, cReachMode.actualReachRange, cReachMode.actualReachRange, cReachMode.projectedReachRange, handMag));

            // Set a destination vector for where the projhand should be
            projDestination = cReachMode.shoulderObject.transform.position + handDisplacement * projMag;

            // Give the Reach Mode the projection's magnitude
            cReachMode.currentDistance = projMag;

            // Slerp the projhand to the destination
            cReachMode.projectedHandObject.transform.position = SuperSmoothLerp(pastFollowerPosition, pastTargetPosition, projDestination, Time.deltaTime, 20f);

            // Save the current positions for the next update slerp
            pastFollowerPosition = cReachMode.projectedHandObject.transform.position;
            pastTargetPosition = projDestination;

            // Mirror the real hand's rotation
            cReachMode.projectedHandObject.transform.rotation = gameObject.transform.rotation;
        }
        else
        {
            // Just hide the renderer, but we'll keep the rest so we don't have to duplicate behaviour on real and proj hands
            cReachMode.isInProjectedState = false;
            cReachHand.model.SetActive(false);
            cReachMode.projectedHandObject.transform.position = cInputHand.gameObject.transform.position;
            pastFollowerPosition = cInputHand.gameObject.transform.position;
        }

    }

    // Method forre-mapping a value to another range
    // From https://rosettacode.org/wiki/Map_range#C.23
    float MapRange(float a1, float a2, float b1, float b2, float s)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

    // From https://forum.unity.com/threads/how-to-smooth-damp-towards-a-moving-target-without-causing-jitter-in-the-movement.130920/
    Vector3 SuperSmoothLerp(Vector3 pastPosition, Vector3 pastTargetPosition, Vector3 targetPosition, float time, float speed)
    {
        Vector3 f = pastPosition - pastTargetPosition + (targetPosition - pastTargetPosition) / (speed * time);
        return targetPosition - (targetPosition - pastTargetPosition) / (speed * time) + f * Mathf.Exp(-speed * time);
    }
    

}

