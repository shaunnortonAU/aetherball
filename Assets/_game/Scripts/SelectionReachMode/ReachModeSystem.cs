using UnityEngine;

public class ReachModeSystem : ISystem
{
    public ReachMode cReachMode;
    public InputHand cInputHand;
    
    private GameObject closePrefab;
    private GameObject actualReachPrefab;
    private GameObject projectedReachPrefab;

    private GameObject projHand;

    Vector3 projDestination;
    
    Vector3 pastFollowerPosition, pastTargetPosition;

    private void Start()
    {
        projHand = Instantiate(cReachMode.projectedHandPrefab);
        cReachMode.projectedHandObject = projHand;
        projHand.GetComponent<ReachSelector>().belongsToReachObject = gameObject;

        if (cReachMode.showRangePrefabs)
        {
            // closePrefab = Instantiate(cReachMode.closePrefab, gameObject.transform);
            // actualReachPrefab = Instantiate(cReachMode.actualReachPrefab, gameObject.transform);
            // projectedReachPrefab = Instantiate(cReachMode.projectedReachPrefab, gameObject.transform);
        }

    }
    private void Update()
    {
        

        if (cReachMode.showRangePrefabs)
        {
            /*
            // Set the range vis prefab sizes
            closePrefab.transform.localScale = new Vector3(2 * cReachMode.closeRange, 2 * cReachMode.closeRange, 2 * cReachMode.closeRange);
            actualReachPrefab.transform.localScale = new Vector3(2 * cReachMode.actualReachRange, 2 * cReachMode.actualReachRange, 2 * cReachMode.actualReachRange);
            projectedReachPrefab.transform.localScale = new Vector3(2 * cReachMode.projectedReachRange, 2 * cReachMode.projectedReachRange, 2 * cReachMode.projectedReachRange);
            
            closePrefab.transform.position = shoulderPosition;
            actualReachPrefab.transform.position = shoulderPosition;
            projectedReachPrefab.transform.position = shoulderPosition;
            */


            // closePrefab.transform.localScale = new Vector3(0.1f , 0.1f, 0.1f);
            // closePrefab.transform.position = shoulderPosition;
        }
        
        Vector3 handDisplacement = cInputHand.gameObject.transform.position - cReachMode.shoulderObject.transform.position;

        float handMag = handDisplacement.magnitude;

        if (handMag > cReachMode.closeRange)
        {
            // Set the Reach Mode state
            cReachMode.isInProjectedState = true;

            // Show the proj hand object
            projHand.SetActive(true);

            // Calculate the projected magnitude based on actual hand magnitude in the close>actual range.
            float projMag = Mathf.Min(cReachMode.projectedReachRange, MapRange(cReachMode.closeRange, cReachMode.actualReachRange, cReachMode.actualReachRange, cReachMode.projectedReachRange, handMag));

            // Set a destination vector for where the projhand should be
            projDestination = cReachMode.shoulderObject.transform.position + handDisplacement * projMag;

            // Give the Reach Mode the projection's magnitude
            cReachMode.currentDistance = projMag;

            // Slerp the projhand to the destination
            projHand.transform.position = SuperSmoothLerp(pastFollowerPosition, pastTargetPosition, projDestination, Time.deltaTime, 20f);

            // Save the current positions for the next update slerp
            pastFollowerPosition = projHand.transform.position;
            pastTargetPosition = projDestination;

        }
        else
        {
            // Turn off stuff
            cReachMode.isInProjectedState = false;
            projHand.SetActive(false);
            projHand.transform.position = cInputHand.gameObject.transform.position;
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

