using UnityEngine;

[System.Serializable]
public class BallType
{
    public string name;
    public Material material;
}

public class BallManager : MonoBehaviour
{
    public BallType[] ballTypes;
    public static BallManager instance = null;
    public GameObject[] ballTargets;
    public GameObject ballContainer;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
}