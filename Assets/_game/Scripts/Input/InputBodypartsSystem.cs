using UnityEngine;

//Put it on the Player
public class InputBodypartsSystem : ISystem
{
    public PlayerInputList cPlayerInputList;

    void Update ()
    {
        // Set the feet position X/Z according to head
        cPlayerInputList.feet.transform.position = new Vector3(cPlayerInputList.head.transform.position.x, 0, cPlayerInputList.head.transform.position.z);

        // Estimate shoulder position
        float bodyHeight = cPlayerInputList.head.transform.position.y - cPlayerInputList.feet.transform.position.y + cPlayerInputList.headUnitOffset;

        float shoulderHeight = bodyHeight * cPlayerInputList.shoulderHeightRatio;
        float shoulderOffset = bodyHeight * cPlayerInputList.shoulderOffsetRatio;

        Vector3 shoulderCenterPosition = cPlayerInputList.feet.transform.position + new Vector3(0, shoulderHeight, 0);
        
        cPlayerInputList.rightShoulder.transform.position = shoulderCenterPosition + shoulderOffset * (0.5f * cPlayerInputList.head.transform.right + 0.5f * (cPlayerInputList.rightHand.transform.position - shoulderCenterPosition).normalized);
        cPlayerInputList.leftShoulder.transform.position = shoulderCenterPosition + shoulderOffset * (-0.5f * cPlayerInputList.head.transform.right + 0.5f * (cPlayerInputList.leftHand.transform.position - shoulderCenterPosition).normalized);

        // Vector3 shoulderCentrePosition = new Vector3(cPlayerInputList.feet.transform.position.x, shoulderHeight, cPlayerInputList.feet.transform.position.z);

    }
}
