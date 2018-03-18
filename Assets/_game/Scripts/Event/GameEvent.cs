using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    private readonly List<GameEventListener> eventListeners = new List<GameEventListener>();

    public void Raise()
    {
        // Iterate in reverse so that a listener can be removed without it affecting the index of the remaining items in the loop.
        for(int i = eventListeners.Count -1; i >= 0; i--)
        {
            eventListeners[i].OnEventRaised();
        }
    }
    public void RegisterListener(GameEventListener listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}
