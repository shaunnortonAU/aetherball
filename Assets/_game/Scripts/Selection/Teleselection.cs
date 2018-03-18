using UnityEngine;
/*
public class STeleselection : MonoBehaviour
{
    private void Update()
    {
        if (GetComponent<CTeleselect_Hand>() && GetComponent<CInputCondition>())
        {
            CTeleselect_Hand cTeleselect_Hand = GetComponent<CTeleselect_Hand>();
            CInputCondition cInputCondition = GetComponent<CInputCondition>();

            if (cInputCondition.conditionMet)
            {
                // Ray casting
                Vector3 lookDirection = transform.position - cTeleselect_Hand.teleselectHead.transform.position;
                float distance = cTeleselect_Hand.maxReach;

                RaycastHit[] hits;
                hits = Physics.RaycastAll(transform.position, lookDirection, distance, cTeleselect_Hand.layerMask);

                Debug.DrawRay(transform.position, lookDirection*distance, Color.green);

                for (int i = 0; i < hits.Length; i++)
                {
                    RaycastHit hit = hits[i];

                    if (hit.transform.gameObject.GetComponent<CTeleselectable>())
                    {
                        CTeleselectable cTeleselectable = hit.transform.gameObject.GetComponent<CTeleselectable>();
                        cTeleselectable.hoveredBy = gameObject;
                        cTeleselectable.hoveringThisFrame = true;

                        cTeleselect_Hand.reticle.GetComponent<CReticle>().isHoveringOver = hit.transform.gameObject;
                    }

                }
            }
        }

        if (GetComponent<CTeleselectable>())
        {
            CTeleselectable cTeleselectable = GetComponent<CTeleselectable>();

            if (!cTeleselectable.isHovered && cTeleselectable.hoveringThisFrame)
            {
                // Debug.Log("Started Hovering");
                cTeleselectable.gameObject.GetComponent<Renderer>().sharedMaterial = cTeleselectable.hoverMaterial;
                cTeleselectable.isHovered = true;
            }
            if (cTeleselectable.isHovered && !cTeleselectable.hoveringThisFrame)
            {
                // Debug.Log("Stopped Hovering");
                cTeleselectable.isHovered = false;
                cTeleselectable.gameObject.GetComponent<Renderer>().sharedMaterial = cTeleselectable.defaultMaterial;
                cTeleselectable.hoveredBy.GetComponent<CTeleselect_Hand>().reticle.GetComponent<CReticle>().isHoveringOver = null;
            }
            if (cTeleselectable.isHovered && cTeleselectable.hoveringThisFrame)
            {
                // Debug.Log("Hovering");
                
                // At the end of the cases, reset this to false so that the next frame must re-set it if true.
                // This gives a default state of not hovering.
                cTeleselectable.hoveringThisFrame = false;
            }
        }


        if (GetComponent<CReticle>())
        {
            CReticle cReticle = GetComponent<CReticle>();

            if (cReticle.isHoveringOver)
            {
                gameObject.GetComponent<Renderer>().enabled = true;
                transform.position = cReticle.isHoveringOver.transform.position;

                Vector3 lookPos = cReticle.hand.transform.position - transform.position;
                Quaternion rotation = Quaternion.LookRotation(lookPos);
                rotation *= Quaternion.Euler(90, 0, 0); // this adds a 90 degrees Y rotation
                transform.rotation = rotation;
                
            }
            else
            {
                gameObject.GetComponent<Renderer>().enabled = false;
            }
        }

        // Hover to guide
        if (GetComponent<CTeleselectable>() && GetComponent<CGuiding>())
        {
            CTeleselectable cTeleselectable = GetComponent<CTeleselectable>();
            CGuiding cGuiding = GetComponent<CGuiding>();

            if (cTeleselectable.isHovered)
            {
                if (!cGuiding.guidingHand)
                {
                    cGuiding.guidingHand = cTeleselectable.hoveredBy;
                    cGuiding.guidingHand.GetComponent<CGuiding_Hand>().startPosition = cGuiding.guidingHand.transform.position;
                }
            }
            if (!cTeleselectable.isHovered)
            {
                cGuiding.guidingHand = null;
            }
        }
        // Hover to lock


        // Lock to guide
    }
}
*/