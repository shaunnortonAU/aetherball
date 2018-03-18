using UnityEngine;

public class CollisionSystem : ISystem
{
    public Collidable cCollidable;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Collidable>())
        {
            cCollidable.collidedThisFrame.Add(other.gameObject);
        }
        
    }

    public void LateUpdate()
    {
        cCollidable.collidedThisFrame.Clear();
    }
}
