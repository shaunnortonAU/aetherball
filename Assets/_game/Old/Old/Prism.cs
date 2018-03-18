using UnityEngine;

public class Prism : MonoBehaviour
{
    public GameObject prismLens;
    public GameObject ballHeld;
    public int ballHeldType = -1;
    public float timeStartedHolding;
    public ushort hapticDuration = 500;

    public void ReceiveCollision(GameObject other)
    {
        if (ballHeldType == -1)
        {
            // Get information about this ball.
            timeStartedHolding = Time.time;

            ballHeld = other;

            Valve.VR.InteractionSystem.Hand hand = GetComponent<Valve.VR.InteractionSystem.PrismInteractable>().activeHand;

            hand.controller.TriggerHapticPulse(hapticDuration);

            ballHeldType = ballHeld.GetComponent<Ball>().ballType;
            // prismLens.GetComponent<Renderer>().sharedMaterial = BallManager.instance.ballTypes[ballHeldType].material;

            ballHeld.GetComponent<Ball>().ballIsHeld = true;
            ballHeld.GetComponent<BallMovement>().stopMoving = true;
            ballHeld.transform.parent = prismLens.transform;
            ballHeld.transform.position = prismLens.transform.position;
            
            PrismManager.instance.PrismReceivedBall();
            // Destroy(other);
        }
    }
}
