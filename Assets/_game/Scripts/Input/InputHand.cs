using UnityEngine;

public class InputHand : IComponent
{
    public GameObject player;
    public GameObject model;

    [System.Serializable]
    public class InputToEvents
    {
        public InputAlias inputAlias;
        public InputEvent inputEvent;
        public bool debugAlwaysOn;
    }

    public InputToEvents[] inputToEvents;
}