using UnityEngine;

public class ReachSelection : ISystem
{
    public ReachSelector cReachSelector;
    public Collidable cCollidable;

    private GameObject objectToAffect;

    public void Update()
    {
        for(int i = 0; i < cCollidable.collidedThisFrame.Count; i++)
        {
            ReachSelectable cReachSelectable = cCollidable.collidedThisFrame[i].GetComponent<ReachSelectable>();
            if (cReachSelectable)
            {
                if (cReachSelector.effectObjectOverride)
                {
                    // Check this object for an override.
                    objectToAffect = cReachSelector.effectObjectOverride;
                }
                else
                {
                    // Check the other object for an override.
                    if(cReachSelectable.effectObjectOverride)
                    {
                        objectToAffect = cReachSelectable.effectObjectOverride;
                    }
                    else
                    {
                        objectToAffect = cCollidable.collidedThisFrame[i];
                    }
                }

                cReachSelector.collideEffect.DoEffect(objectToAffect);
            }
        }
    }
}
