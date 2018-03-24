using UnityEngine;
using System.Collections.Generic;

public class Collidable : IComponent
{
    // List of collisions this frame. Cleared after every frame.
    public List<GameObject> collidedThisFrame;

    public bool onTriggerStay;

        /* Debugging
    private void Update()
    {
        for (int i = 0; i < collidedThisFrame.Count; i++)
            Debug.Log(collidedThisFrame[i]);
    }
    */
}
 