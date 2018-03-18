using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineInstance : ISystem
{
    public static CoroutineInstance instance;

    void Start()
    {
        CoroutineInstance.instance = this;
    }
}