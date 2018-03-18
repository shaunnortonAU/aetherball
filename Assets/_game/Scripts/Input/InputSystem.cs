using UnityEngine;

public class InputSystem : ISystem
{
    private void Update()
    {
        /*
        if (GetComponent<CInputState>())
        {
            CInputState cInputState = GetComponent<CInputState>();

            if (cInputState.handObject.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
            {
                cInputState.pinchOn = true;
            }
            if (cInputState.handObject.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip))
            {
                cInputState.gripOn = true;
            }
        }
        if (GetComponent<CInputCondition>())
        {
            CInputCondition cInputCondition = GetComponent<CInputCondition>();
            CInputState cInputState = cInputCondition.hand.GetComponent<CInputState>();

            if (cInputCondition.pinchOn == cInputState.pinchOn && cInputCondition.gripOn == cInputState.gripOn)
            {
                cInputCondition.conditionMet = true;
            }
        }
*/
    }
}