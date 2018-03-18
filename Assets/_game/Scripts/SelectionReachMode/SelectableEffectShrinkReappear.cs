using UnityEngine;
using System.Collections;

public class SelectableEffectShrinkReappear : IEffect
{
    public bool isDead;
    public float reappearTime;

    public override void DoEffect(GameObject obj)
    {
        if (!isDead)
        {
            isDead = true;
            obj.SetActive(false);
            CoroutineInstance.instance.StartCoroutine(Effecting(obj));
        }
    }

    IEnumerator Effecting(GameObject obj)
    {
        yield return new WaitForSeconds(reappearTime);
        isDead = false;
        obj.SetActive(true);
        yield return null;
    }
}
