using UnityEngine;

public class Ball : MonoBehaviour
{
    public int ballType = 0;
    public bool ballIsHeld = false;
    public bool ballIsBeamed = false;
    public GameObject ballModel;

    public float timeToLive = 10.0f;
    public float timeOfBirth;

    private void Start()
    {
        timeOfBirth = Time.time;
    }

    public void Update()
    {
        if (!ballIsHeld)
        {
            float ballTimePercent = (Time.time - timeOfBirth) / timeToLive;
            float ballScale = Mathf.Lerp(1.0f, 0.1f, ballTimePercent);
            gameObject.transform.localScale = new Vector3(ballScale, ballScale, ballScale);

            if (Time.time > timeOfBirth + timeToLive)
            {
                Destroy(gameObject);
            }
        }
    }
}
