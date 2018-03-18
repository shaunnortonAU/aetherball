using System;
using UnityEngine;

[Serializable]
public class FloatReference
{
    public FloatVariable defaultValue;
    public float copyValue;

    public float CopyValue
    {
        get { return copyValue; }
        set { copyValue = value; }
    }

    public void OnEnable()
    {
        copyValue = defaultValue.value;
    }
}
