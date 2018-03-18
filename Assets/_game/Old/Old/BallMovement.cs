using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Transform moveTarget;
    public bool moveToTarget = true;
    public float speed;
    public bool stopMoving;
    public float maxDistance = 20.0f;

    void Update()
    {
        if (!stopMoving)
        {
            float step = speed * Time.deltaTime;
            if (moveToTarget)
            {
                transform.position = Vector3.MoveTowards(transform.position, moveTarget.position, step);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.forward * maxDistance, step);
            }
        }
    }
}
