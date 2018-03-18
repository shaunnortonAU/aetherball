using UnityEngine;

public class BallSeeking : ISystem
{
    public BallSeeks cBallSeeks;
	
	// Update is called once per frame
	void Update () {
        // Refer to the relevant components

        // Get the rotation required to look at the target
        Quaternion rotation = Quaternion.LookRotation(cBallSeeks.target.transform.position - transform.position);

        // Rotate with slerp to limit turn radius
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.fixedDeltaTime * cBallSeeks.rotationDamper);
    }
}
