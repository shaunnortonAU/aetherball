using UnityEngine;

public class NodeParticleAligning : ISystem
{
    public NodeParticle cNodeParticle;
    public NodeParticleAligned cNodeParticleAligned;

    private NodeVector cBelongsToNodeVector;

    private void Start()
    {
        cBelongsToNodeVector = cNodeParticle.belongsToNodeObject.GetComponent<NodeVector>();
        AlignParticle();
    }
    
    private void Update()
    {
        if (cBelongsToNodeVector.isUpdated)
        {
            AlignParticle();
        }
    }

    private void AlignParticle()
    {
        cNodeParticleAligned.gameObject.transform.rotation = Quaternion.LookRotation(cBelongsToNodeVector.forceVector);
    }

}
