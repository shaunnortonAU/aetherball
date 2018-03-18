using UnityEngine;

public class BallBodySizeSystem : ISystem
{ 
    public BallBody cBallBody;

    void Update () {
        if(cBallBody)
            transform.localScale = new Vector3(cBallBody.size.scale, cBallBody.size.scale, cBallBody.size.scale);
    }
}
