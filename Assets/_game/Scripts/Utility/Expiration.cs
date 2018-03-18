using UnityEngine;

public class Expiration : ISystem
{
    public Expires cExpires;
    public void Start()
    {
        cExpires.timeOfBirth = Time.time;
    }
    private void Update()
    {
        if (Time.time > cExpires.timeOfBirth + cExpires.timeToLive)
        {
            Destroy(gameObject);
        }
    }
}