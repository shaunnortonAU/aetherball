using UnityEngine;
using System.Collections.Generic;

public class Collidable : IComponent
{
    // List of collisions this frame. Cleared after every frame.
    [HideInInspector]
    public List<GameObject> collidedThisFrame;
}