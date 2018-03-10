using UnityEngine;

public class Beam : MonoBehaviour
{
    public GameObject[] balls = new GameObject[2];
    public GameObject lineRenderer;

    public float timeToLive = 10.0f;
    public float timeOfBirth;
    public LayerMask layerMask;

    public void Update()
    {
        if (Time.time > timeOfBirth + timeToLive)
        {
            Destroy(gameObject);
        }
        else
        {
            // Line Renderer
            Vector3[] linePositions = new Vector3[2];
            linePositions[0] = balls[0].transform.position;
            linePositions[1] = balls[1].transform.position;
            lineRenderer.GetComponent<LineRenderer>().SetPositions(linePositions);

            // Ray casting
            Vector3 lookDirection = balls[1].transform.position - balls[0].transform.position;
            float distance = Vector3.Distance(balls[1].transform.position, balls[0].transform.position);

            RaycastHit[] hits;
            hits = Physics.RaycastAll(balls[0].transform.position, lookDirection, distance, layerMask);
            
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];

                if (hit.transform.gameObject.GetComponent<CollisionForwarder>() != null)
                {
                    hit.transform.gameObject.GetComponent<CollisionForwarder>().OnRaycastHit();
                }

            }
        }
    }

}
