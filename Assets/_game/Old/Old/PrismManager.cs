using System;
using UnityEngine;

public class PrismManager : MonoBehaviour
{
    public static PrismManager instance = null;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    // Prisms
    public GameObject[] prismObjects;

    // Balls
    public float timeToHoldBall = 1.5f;

    // Link
    private bool currentlyLinked = false;
    public GameObject linkRenderer;
    public float timeToHoldLink = 2.0f;
    private float timeStartedLinking;
    public float beamSpeed = 2.0f;
    private int currentLinkType = -1;

    // Beams
    public GameObject beamPrefab;
    public float beamTimeToLive;

    public void Update()
    {
        if (currentlyLinked)
        {
            if (Time.time < timeStartedLinking + timeToHoldLink)
            {
                Vector3[] linePositions = new Vector3[2];
                linePositions[0] = prismObjects[0].GetComponent<Prism>().prismLens.transform.position;
                linePositions[1] = prismObjects[1].GetComponent<Prism>().prismLens.transform.position;
                linkRenderer.GetComponent<LineRenderer>().SetPositions(linePositions);

                float linkHoldTimePercent = (Time.time - timeStartedLinking) / timeToHoldLink;
                float linkScale = Mathf.Lerp(0.18f, 0.02f, linkHoldTimePercent);
                linkRenderer.GetComponent<LineRenderer>().widthMultiplier = linkScale;
            }
            else
            {
                ShootBeam();
                currentlyLinked = false;
                linkRenderer.GetComponent<LineRenderer>().enabled = false;
            }
        }
        else
        {
            foreach (GameObject prismObject in prismObjects)
            {
                Prism prismComponent = prismObject.GetComponent<Prism>();
                if (prismComponent.ballHeld != null)
                {
                    float ballHoldTimePercent = (Time.time - prismComponent.timeStartedHolding) / timeToHoldBall;
                    float ballScale = Mathf.Lerp(1.0f, 0.1f, ballHoldTimePercent);
                    prismComponent.ballHeld.transform.localScale = new Vector3(ballScale, ballScale, ballScale);

                    if (Time.time > prismComponent.timeStartedHolding + timeToHoldBall)
                    {
                        currentLinkType = -1;
                        prismComponent.ballHeldType = -1;
                        Destroy(prismComponent.ballHeld);
                    }
                }
            }
        }
    }

    public void PrismReceivedBall()
    {
        if(prismObjects[0].GetComponent<Prism>().ballHeldType == prismObjects[1].GetComponent<Prism>().ballHeldType)
        {
            ActivateLink();
        }
    }

    public void ActivateLink()
    {
        if (currentlyLinked == false)
        {
            currentlyLinked = true;
            currentLinkType = prismObjects[0].GetComponent<Prism>().ballHeldType;
            timeStartedLinking = Time.time;
            linkRenderer.GetComponent<LineRenderer>().enabled = true;
            linkRenderer.GetComponent<LineRenderer>().material = BallManager.instance.ballTypes[currentLinkType].material;
        }
    }

    public void ShootBeam()
    {
        Transform playerCamera = GameManager.instance.playerCamera.transform;
        GameObject beam = Instantiate(beamPrefab);
        beam.transform.parent = BallManager.instance.ballContainer.transform;
        beam.GetComponent<Beam>().lineRenderer.GetComponent<LineRenderer>().material = BallManager.instance.ballTypes[currentLinkType].material;
        beam.GetComponent<Beam>().timeOfBirth = Time.time;
        beam.GetComponent<Beam>().timeToLive = beamTimeToLive;

        for (int i = 0; i < prismObjects.Length; i++)
        {
            GameObject ball = prismObjects[i].GetComponent<Prism>().ballHeld;

            beam.GetComponent<Beam>().balls[i] = prismObjects[i].GetComponent<Prism>().ballHeld;

            prismObjects[i].GetComponent<Prism>().ballHeld = null;
            prismObjects[i].GetComponent<Prism>().ballHeldType = -1;


            // NOT USED: Make the balls look away from player camera
            // ball.transform.rotation = Quaternion.LookRotation(ball.transform.position - playerCamera.position);
            
            ball.transform.parent = beam.transform;
            ball.transform.rotation = prismObjects[i].GetComponent<Prism>().prismLens.transform.rotation;
            ball.GetComponent<Ball>().ballIsHeld = false;
            ball.GetComponent<Ball>().ballIsBeamed = true;
            ball.GetComponent<Ball>().timeOfBirth = Time.time;
            ball.GetComponent<Ball>().timeToLive = beamTimeToLive;
            ball.GetComponent<Ball>().ballModel.SetActive(false);
            ball.GetComponent<BallMovement>().stopMoving = false;
            ball.GetComponent<BallMovement>().moveToTarget = false;
            ball.GetComponent<BallMovement>().speed = beamSpeed;
            ball.GetComponent<BallMovement>().maxDistance = beamSpeed*beamTimeToLive;
        }


    }
}
