using UnityEngine;

public class PlayerInputList : IComponent
{
    public GameObject head;
    public GameObject rightHand;
    public GameObject rightShoulder;
    public GameObject leftHand;
    public GameObject leftShoulder;
    public GameObject feet;

    public float headUnitOffset = 0.1f;
    public float shoulderHeightRatio = 0.83f;
    public float shoulderOffsetRatio = 0.14f;
}
