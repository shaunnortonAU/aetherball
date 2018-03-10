using UnityEngine;

public class Beacon : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject ballOrigin;

    public int ballType;
    public bool randomBallType = true;

    public GameObject ballTarget;
    public bool randomTarget = true;

    public float ballSpeed = 1.0f;
    public float ballTimeToLive = 10.0f;

    public float cooldown = 1.0f;
    private float lastShotTime = float.MinValue;

    private void Update()
    {
        if(Time.time > (lastShotTime + cooldown))
        {
            LaunchBall();
            lastShotTime = Time.time;
        }
    }

    private void LaunchBall()
    {
        if (randomTarget)
        {
            GameObject[] ballTargets = BallManager.instance.ballTargets;
            int thisTarget = Random.Range(0, ballTargets.Length);
            ballTarget = ballTargets[thisTarget];
        }

        GameObject ball = Instantiate(ballPrefab, BallManager.instance.ballContainer.transform);

        if (randomBallType)
        {
            ballType = Random.Range(0, BallManager.instance.ballTypes.Length);
        }

        ball.GetComponent<Ball>().ballType = ballType;
        ball.GetComponent<Ball>().timeToLive = ballTimeToLive;
        ball.GetComponent<Ball>().ballModel.GetComponent<Renderer>().sharedMaterial = BallManager.instance.ballTypes[ballType].material;

        ball.transform.position = ballOrigin.transform.position;
        ball.GetComponent<BallMovement>().moveTarget = ballTarget.transform;
        ball.GetComponent<BallMovement>().speed = ballSpeed;
    }
}
