using UnityEngine;

public class BallInertiaMovement : ISystem
{
    public BallInertia cInertia;
    
    void Update ()
    {
        cInertia.inertia = Vector3.ClampMagnitude(cInertia.inertia, cInertia.maxSqrMagVelocity);
        transform.position += cInertia.inertia;
    }
}
