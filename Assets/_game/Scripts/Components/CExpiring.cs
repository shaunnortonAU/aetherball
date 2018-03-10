using UnityEngine;

public class CExpiring : MonoBehaviour
{
    public float timeToLive;
    public bool extendOnInteraction;
    public float timeOfBirth;

    public void Start()
    {
        timeOfBirth = Time.time;
    }
}