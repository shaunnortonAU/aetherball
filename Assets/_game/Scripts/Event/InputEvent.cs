using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu]
public class InputEvent : ScriptableObject
{
    private readonly List<InputEventListener> eventListeners = new List<InputEventListener>();

    public void Raise(GameObject obj)
    {
        // Iterate in reverse so that a listener can be removed without it affecting the index of the remaining items in the loop.
        for(int i = eventListeners.Count -1; i >= 0; i--)
        {
            eventListeners[i].OnEventRaised(obj);
        }
    }
    public void RegisterListener(InputEventListener listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(InputEventListener listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}
