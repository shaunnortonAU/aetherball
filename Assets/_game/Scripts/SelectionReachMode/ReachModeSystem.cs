using UnityEngine;

public class ReachModeSystem : ISystem
{
    public ReachMode cReachMode;
    public InputHand cInputHand;

    private PlayerInputList cPlayerInputList;
    private GameObject closePrefab;
    private GameObject actualReachPrefab;
    private GameObject projectedReachPrefab;

    private GameObject projHand;

    Vector3 projDestination;

    //Vector3 followerVelocity;
    Vector3 pastFollowerPosition, pastTargetPosition;

    private void Start()
    {
        projHand = Instantiate(cReachMode.projectedHandPrefab);

        cPlayerInputList = cInputHand.player.GetComponent<PlayerInputList>();

        if (cReachMode.showRangePrefabs)
        {
            closePrefab = Instantiate(cReachMode.closePrefab, gameObject.transform);
            actualReachPrefab = Instantiate(cReachMode.actualReachPrefab, gameObject.transform);
            projectedReachPrefab = Instantiate(cReachMode.projectedReachPrefab, gameObject.transform);
        }

    }
    private void Update()
    {
        //Get positions from player parts
        Vector3 playerMiddle = cPlayerInputList.gameObject.transform.position + (cPlayerInputList.head.transform.position - cPlayerInputList.feet.transform.position) / 2;

        if (cReachMode.showRangePrefabs)
        {
            // Set the range vis prefab sizes
            closePrefab.transform.localScale = new Vector3(2 * cReachMode.closeRange, 2 * cReachMode.closeRange, 2 * cReachMode.closeRange);
            actualReachPrefab.transform.localScale = new Vector3(2 * cReachMode.actualReachRange, 2 * cReachMode.actualReachRange, 2 * cReachMode.actualReachRange);
            projectedReachPrefab.transform.localScale = new Vector3(2 * cReachMode.projectedReachRange, 2 * cReachMode.projectedReachRange, 2 * cReachMode.projectedReachRange);
            
            closePrefab.transform.position = playerMiddle;
            actualReachPrefab.transform.position = playerMiddle;
            projectedReachPrefab.transform.position = playerMiddle;
        }
        
        Vector3 handDisplacement = cInputHand.gameObject.transform.position - playerMiddle;

        double handMag = handDisplacement.magnitude;

        if (handMag > cReachMode.closeRange && handMag < cReachMode.actualReachRange)
        {
            // Show the proj hand object
            projHand.SetActive(true);

            // Calculate the projected magnitude based on actual hand magnitude in the close>actual range.
            double projMag = MapRange(cReachMode.closeRange, cReachMode.actualReachRange, cReachMode.actualReachRange, cReachMode.projectedReachRange, handMag);

            // Set a destination vector for where the projhand should be
            projDestination = playerMiddle + handDisplacement * (float)projMag;

            // Slerp the projhand to the destination
            projHand.transform.position = SuperSmoothLerp(pastFollowerPosition, pastTargetPosition, projDestination, Time.deltaTime, 20f);

            // Save the current positions for the next update slerp
            pastFollowerPosition = projHand.transform.position;
            pastTargetPosition = projDestination;

        }
        else
        {
            projHand.SetActive(false);
            projHand.transform.position = cInputHand.gameObject.transform.position;
            pastFollowerPosition = cInputHand.gameObject.transform.position;
        }

    }

    // Method forre-mapping a value to another range
    // From https://rosettacode.org/wiki/Map_range#C.23
    double MapRange(double a1, double a2, double b1, double b2, double s)
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

