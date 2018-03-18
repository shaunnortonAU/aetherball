using UnityEngine;

public class BallSpawner : IComponent
{
    public GameObject prefabToSpawn;
    public float spawnTimer;
    public float timeOfLastSpawn;
    public float forwardVelocity;
}