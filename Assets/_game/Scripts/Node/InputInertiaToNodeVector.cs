using UnityEngine;

public class InputInertiaToNodeVector : ISystem
{
    public Inertia cInertia;
    public Collidable cCollidable;
    private bool inputReceived;
    
    public void ReceiveInput()
    {
        inputReceived = true;
    }

    public void Update()
    {
        if (inputReceived)
        {
            for (int i = 0; i < cCollidable.collidedThisFrame.Count; i++)
            {
                NodeVector cNodeVector = cCollidable.collidedThisFrame[i].GetComponent<NodeVector>();
                if (cNodeVector)
                {
                    cNodeVector.forceVector = cInertia.inertia;
                    cNodeVector.isUpdated = true;
                }
            }
        }
    }
}
