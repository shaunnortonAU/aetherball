using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public static TargetManager instance = null;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public GameObject[] targets;
    public int livingTargets;
    public GameObject targetContainer;

    public void TargetWasHit()
    {
        foreach(GameObject target in targets)
        {
            if (!target.GetComponent<Target>().isDead)
            {
                livingTargets++;
            }
        }
        if(livingTargets == 0)
        {
            targetContainer.SetActive(false);
        }
    }

}
