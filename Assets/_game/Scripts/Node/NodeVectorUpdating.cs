using UnityEngine;

public class NodeVectorUpdating : ISystem
{
    public NodeVector cNodeVector;
	void LateUpdate ()
    {
        if (cNodeVector.isUpdated)
            cNodeVector.isUpdated = false;
    }
}
