using UnityEngine;

public class Target : MonoBehaviour
{
    public bool isDead = false;
    public float timeOfDeath;
    public float timeToDieOut = 2.0f;
    public float respawnTimer = 5.0f;
    public float timeOfRespawn;
    public float timeToRespawn = 0.5f;

    public void ReceiveRaycast()
    {
        isDead = true;
        timeOfDeath = Time.time;

        TargetManager.instance.TargetWasHit();
    }

    public void Update()
    {
        if (isDead)
        {
            float deadTimePercent = (Time.time - timeOfDeath) / timeToDieOut;
            float targetScale = Mathf.Lerp(1.0f, 0.1f, deadTimePercent);
            gameObject.transform.localScale = new Vector3(targetScale, targetScale, targetScale);
        }
        if(isDead && Time.time > timeOfDeath + respawnTimer)
        {
            isDead = false;
            float timePercent = (Time.time - timeOfRespawn) / timeToRespawn;
            float targetScale = Mathf.Lerp(0.1f, 1f, timePercent);
            gameObject.transform.localScale = new Vector3(targetScale, targetScale, targetScale);
        }
    }
}
