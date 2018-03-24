using UnityEngine;

public class InertiaPolling : ISystem
{
    public Inertia cInertia;
    public InertiaPoll cInertiaPoll;

    private void Start()
    {
        cInertiaPoll.handStartPosition = gameObject.transform.position;
    }

    void FixedUpdate ()
    {
		if(Time.time > cInertiaPoll.lastPollTime + cInertiaPoll.pollInterval)
        {
            cInertiaPoll.lastPollTime = Time.time;
            cInertia.inertia = Time.fixedDeltaTime * (gameObject.transform.position - cInertiaPoll.handStartPosition) / cInertiaPoll.pollInterval;
            cInertiaPoll.handStartPosition = gameObject.transform.position;
        }
	}
}
