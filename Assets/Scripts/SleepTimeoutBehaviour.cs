using UnityEngine;

public class SleepTimeoutBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
    }

}
