using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealTimeTimer : MonoBehaviour
{

    [SerializeField]
    float _Timer;
    public float Timer
    {
        get { return _Timer; }
        private set { _Timer = value; }
    }

    bool active;
    float StartTime, StopTime;
    public void Stop()
    {
        StopTime = Time.realtimeSinceStartup;
        active = false;
    }
    public void ReStart()
    {
        StartTime += Time.realtimeSinceStartup - StopTime;
        active = true;
    }
    public void Reset()
    {
        Start();
    }
    void Start()
    {
        StartTime = Time.realtimeSinceStartup;
        active = true;
    }

    void Update()
    {
        if (active)
        {
            Timer = Time.realtimeSinceStartup - StartTime;
        }
    }
}
