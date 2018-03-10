using UnityEngine;

public class CollisionForwarder : MonoBehaviour
{
    // The object to send collision info to
    // This could be genericised
    public GameObject forwardTo;

    // Only send collision if the other object has this tag
    public string filterToTag;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == filterToTag)
        {
            forwardTo.GetComponent<Prism>().ReceiveCollision(collider.gameObject.transform.parent.gameObject);
        }
    }

    public void OnRaycastHit()
    {
        forwardTo.GetComponent<Target>().ReceiveRaycast();
    }

}
