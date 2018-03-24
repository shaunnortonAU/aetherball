using UnityEngine;

[CreateAssetMenu]
public class InputAlias : ScriptableObject
{
    public string buttonName;
    public Valve.VR.EVRButtonId buttonId;

    public bool overrideEnabled;
    
    public string keyOverride;
}
