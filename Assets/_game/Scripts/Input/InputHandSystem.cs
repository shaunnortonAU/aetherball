using UnityEngine;
using Valve.VR.InteractionSystem;

public class InputHandSystem : MonoBehaviour
{
    public InputHand cInputHand;

    private void Update()
    {
        for(int i=0; i < cInputHand.inputToEvents.Length; i++)
        {
            if (cInputHand.inputToEvents[i].debugAlwaysOn || Input.GetKey(cInputHand.inputToEvents[i].inputAlias.keyOverride))
            {
                cInputHand.inputToEvents[i].inputEvent.Raise(gameObject);
            }
        }
    }
}
