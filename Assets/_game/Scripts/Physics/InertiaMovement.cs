using UnityEngine;

public class InertiaMovement : ISystem
{
    public Inertia cInertia;
    
    void FixedUpdate ()
    {
        cInertia.inertia = Vector3.ClampMagnitude(cInertia.inertia, cInertia.maxSqrMagVelocity);
        transform.position += cInertia.inertia;
    }
}
