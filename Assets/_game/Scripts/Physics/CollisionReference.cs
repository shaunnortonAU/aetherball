using UnityEngine;

public class CollisionReference : IComponent
{
    public GameObject collidedWithObject;
    public void SetObject(GameObject obj)
    {
        collidedWithObject = obj;
    }
}
