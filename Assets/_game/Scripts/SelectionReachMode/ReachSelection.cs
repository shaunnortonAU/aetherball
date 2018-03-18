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
            if (cCollidable.collidedThisFrame[i].GetComponent<ReachSelectable>())
            {
                objectToAffect = (cReachSelector.affectThis) ? gameObject : cCollidable.collidedThisFrame[i];
                cReachSelector.collideEffect.DoEffect(objectToAffect);
            }
        }
    }
}
