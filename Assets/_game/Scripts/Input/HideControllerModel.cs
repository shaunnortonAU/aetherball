using UnityEngine;

public class HideControllerModel : ISystem
{
    public GameObject[] controllerObjects;
    private bool hasRun;

    private void Update()
    {
        if (!hasRun)
        {
            SetControllerVisible(controllerObjects, false);
            hasRun = true;
        }
    }

    void SetControllerVisible(GameObject[] controllers, bool visible)
    {
        foreach (GameObject controller in controllers)
            controller.SetActive(visible);
    }

}
