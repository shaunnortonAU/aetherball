using UnityEngine;

public class BallSpawning : ISystem
{
    public BallSpawner cBallSpawner;

    private void Update()
    {
        // Has enough time passed since last spawning?
        if (Time.time > cBallSpawner.timeOfLastSpawn + cBallSpawner.spawnTimer)
        {
            // Instantiate the prefab
            GameObject newObject = Instantiate(cBallSpawner.prefabToSpawn);

            // Set the position of the instantiated object from the Transform component
            newObject.transform.position = transform.position;

            // Set the rotation
            newObject.transform.rotation = transform.rotation;

            // Set the velocity
            Inertia newObjectInertia = newObject.GetComponent<Inertia>();
            if (newObject.GetComponent<Inertia>())
            {
                newObjectInertia.inertia = cBallSpawner.forwardVelocity * transform.forward;
            }

            // Set the current time to the spawner last spawned time
            cBallSpawner.timeOfLastSpawn = Time.time;
        }
    }
}
