using UnityEngine;

public class BallGuided : IComponent
{
    public GameObject guidingHand;
    public float guidingVelocityMultiplier = 0.5f;
    public float guidingVelocityNudge;
}
