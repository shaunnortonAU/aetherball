using UnityEngine;

public class ReachSelector : IComponent
{
    public GameObject belongsToReachObject;
    public IEffect collideEffect;
    public GameObject effectObjectOverride;
}
