using UnityEngine;

public class BallNodeReaction : ISystem
{
    public BallNodeReactor cBallNodeReactor;
    public Inertia cBallInertia;
    
    private void OnTriggerEnter(Collider collider)
    {
        NodeVector cNodeVector = collider.gameObject.GetComponent<NodeVector>();

        if (cNodeVector)
        {
            Vector3 newInertia = new Vector3();

            if (cNodeVector.additive)
            {
                newInertia = cBallInertia.inertia * cBallNodeReactor.inertiaWeight + cNodeVector.forceVector * cBallNodeReactor.nodeWeight;
            }

            else
            {
                newInertia = cNodeVector.forceVector.normalized * cBallInertia.inertia.magnitude;
            }

            cBallInertia.inertia = Vector3.ClampMagnitude(newInertia, cBallInertia.maxSqrMagVelocity);
        }
    }
}
