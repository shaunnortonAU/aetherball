using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllSystems : MonoBehaviour {

    /*
     * This is a super hacky version of ECS systems.
     * It is applied to all ECS objects.
     * Using a lot of IF conditions to match the components on the object.
     * if(GetComponent<>())
     * I am using this method to give me control over the order of execution.
     * And only have 1 update function.
    */

    private void Update()
    {

        // Guiding Movement System
        if (GetComponent<CMoving>() && GetComponent<CGuiding>() && GetComponent<Transform>())
        {
            // Refer to the relevant components
            CMoving cMoving = GetComponent<CMoving>();
            CGuiding cGuiding = GetComponent<CGuiding>();
            
            // Get the guiding hand entity
            GameObject guidingHand = cGuiding.guidingHand;

            // Method 1: Guiding relative to position of hand at start of guide.
            // Get the relative change in position
            Vector3 deltaPosition = guidingHand.transform.position - guidingHand.GetComponent<CGuiding_Hand>().startPosition;

            Vector3 guidingVector = new Vector3(
                Mathf.Max(cGuiding.guidingVelocityNudge, cMoving.velocity.x) * cGuiding.guidingVelocityMultiplier * Mathf.Clamp(deltaPosition.x, -guidingHand.GetComponent<CGuiding_Hand>().maxGuidingSpan, guidingHand.GetComponent<CGuiding_Hand>().maxGuidingSpan),
                Mathf.Max(cGuiding.guidingVelocityNudge, cMoving.velocity.y) * cGuiding.guidingVelocityMultiplier * Mathf.Clamp(deltaPosition.y, -guidingHand.GetComponent<CGuiding_Hand>().maxGuidingSpan, guidingHand.GetComponent<CGuiding_Hand>().maxGuidingSpan),
                Mathf.Max(cGuiding.guidingVelocityNudge, cMoving.velocity.z) * cGuiding.guidingVelocityMultiplier * Mathf.Clamp(deltaPosition.z, -guidingHand.GetComponent<CGuiding_Hand>().maxGuidingSpan, guidingHand.GetComponent<CGuiding_Hand>().maxGuidingSpan)
                );
            cMoving.velocity = guidingVector;
        }
        
        // Spawning System
        if (GetComponent<CSpawning>() && GetComponent<Transform>())
        {
            // Refer to the relevant components
            CSpawning cSpawning = GetComponent<CSpawning>();
            Transform cTransform = GetComponent<Transform>();

            // Has enough time passed since last spawning?
            if (Time.time > cSpawning.timeOfLastSpawn + cSpawning.spawnTimer)
            {
                // Instantiate the prefab
                GameObject spawnedObject = Instantiate(cSpawning.prefabToSpawn);

                // Set the position of the instantiated object from the Transform component
                spawnedObject.transform.position = cTransform.position;

                // Set the rotation
                spawnedObject.transform.rotation = cTransform.rotation;

                // Set the velocity
                if (spawnedObject.GetComponent<CMoving>())
                {
                    spawnedObject.GetComponent<CMoving>().velocity = cSpawning.forwardVelocity * cTransform.forward;
                }

                // Set the current time to the spawner last spawned time
                cSpawning.timeOfLastSpawn = Time.time;
            }
        }

        // Time to Live System
        if (GetComponent<CExpiring>())
        {
            // Refer to the relevant components
            CExpiring cExpiring = GetComponent<CExpiring>();

            if(Time.time > cExpiring.timeOfBirth + cExpiring.timeToLive)
            {
                Destroy(gameObject);
            }
        }

        // Body System
        if (GetComponent<CBody>() && GetComponent<Transform>())
        {
            // Refer to the relevant components
            CBody cBody = GetComponent<CBody>();
            Transform cTransform = GetComponent<Transform>();

            float bodyScale = cBody.size / 5f;
            cTransform.localScale = new Vector3(bodyScale, bodyScale, bodyScale);
        }
    }

    private void FixedUpdate()
    {

        // Seeking System
        // This may or may not work. I haven't tested it with moving objects.
        if (GetComponent<CSeeking>() && GetComponent<Transform>())
        {
            // Refer to the relevant components
            CSeeking cSeeking = GetComponent<CSeeking>();
            Transform cTransform = GetComponent<Transform>();

            // Get the rotation required to look at the target
            Quaternion rotation = Quaternion.LookRotation(cSeeking.target.transform.position - cTransform.position);

            // Rotate with slerp to limit turn radius
            cTransform.rotation = Quaternion.Slerp(cTransform.rotation, rotation, Time.fixedDeltaTime * cSeeking.rotationDamper);
        }

        // Movement System
        if (GetComponent<CMoving>() && GetComponent<Transform>())
        {
            // Refer to the relevant components
            CMoving cMoving = GetComponent<CMoving>();
            Transform cTransform = GetComponent<Transform>();

            float velMagnitude = cMoving.velocity.magnitude;
            if (velMagnitude != 0)
            {
                if (velMagnitude > cMoving.maxSpeed)
                {
                    cMoving.velocity = Vector3.ClampMagnitude(cMoving.velocity, cMoving.maxSpeed);
                }
                cTransform.position += cMoving.velocity;
            }
        }
    }
}
