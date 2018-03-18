using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    [RequireComponent(typeof(Interactable))]
    public class PrismInteractable : MonoBehaviour
    {
        public Hand activeHand;
        
        // Called every Update() while a Hand is hovering over this object
        private void HandHoverUpdate(Hand hand)
        {
            Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags;
            if ((hand.controller != null) && hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip))
            {
                if (hand.currentAttachedObject != gameObject)
                {
                    // Call this to continue receiving HandHoverUpdate messages, and prevent the hand from hovering over anything else
                    hand.HoverLock(GetComponent<Interactable>());

                    // Attach this object to the hand
                    hand.AttachObject(gameObject, attachmentFlags);

                    hand.transform.Find("ControllerHoverHighlight").gameObject.SetActive(false);
                    hand.transform.Find("ControllerButtonHints").gameObject.SetActive(false);
                }
                else
                {
                    activeHand = null;
                    // Detach this object from the hand
                    hand.DetachObject(gameObject);

                    // Call this to undo HoverLock
                    hand.HoverUnlock(GetComponent<Interactable>());

                    hand.transform.Find("ControllerHoverHighlight").gameObject.SetActive(true);
                    hand.transform.Find("ControllerButtonHints").gameObject.SetActive(true);
                }
            }
        }
    }
}