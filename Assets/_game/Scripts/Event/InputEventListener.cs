using UnityEngine;
using UnityEngine.Events;

public class InputEventListener : MonoBehaviour
{
    public GameObject listenToObject;
    public InputEvent Event;
    public UnityEvent Response;


    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(GameObject obj)
    {
        if(listenToObject == obj)
            Response.Invoke();
    }
}
