using UnityEngine;

public class NodeParticleScaling : ISystem
{
    public NodeParticle cNodeParticle;
    public NodeParticleScales cNodeParticleScales;

    private NodeVector cBelongsToNodeVector;

    private void Start()
    {
        cBelongsToNodeVector = cNodeParticle.belongsToNodeObject.GetComponent<NodeVector>();
        ScaleParticle();
    }

    private void Update()
    {
        if (cBelongsToNodeVector.isUpdated)
        {
            ScaleParticle();
        }
    }

    private void ScaleParticle()
    { 
        var main = cNodeParticle.cParticleSystem.main;
        float scaleFactor = Mathf.Min(1, cBelongsToNodeVector.forceVector.sqrMagnitude / cBelongsToNodeVector.maxSqrMagnitude);

        main.startSize = Mathf.Max(cNodeParticleScales.minParticleSize, cNodeParticleScales.maxParticleSize * scaleFactor);
        main.startSpeed = Mathf.Max(cNodeParticleScales.minParticleSpeed, cNodeParticleScales.maxParticleSpeed * scaleFactor);
    }
}
