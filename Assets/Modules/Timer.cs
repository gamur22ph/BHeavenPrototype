using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public delegate void OnTimeoutDelegate();
    public event OnTimeoutDelegate OnTimeOut;
    public float waitTime = 1;
    [HideInInspector]
    public float timeLeft;
    public bool autoStart;
    public bool oneShot;

    // Start is called before the first frame update
    void Start()
    {
        if (autoStart)
        {
            timeLeft = waitTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft = Mathf.Clamp(timeLeft - Time.deltaTime, 0, waitTime);
            if (timeLeft == 0)
            {
                OnTimeOut?.Invoke();
                if (!oneShot) timeLeft = waitTime;
            }
        }
    }

    public void StartTimer()
    {
        timeLeft = waitTime;
    }


}
