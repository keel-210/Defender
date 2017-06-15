using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStrict : MonoBehaviour
{
    [SerializeField]
    RealTimeTimer timer;
    [SerializeField]
    float StrictTime;
    
    float Old_TimeScale;
    bool StrictFlg;
	
	void Update ()
    {
		if(timer.Timer > StrictTime && !StrictFlg)
        {
            timer.Stop();
            Old_TimeScale = Time.timeScale;
            Time.timeScale = 0;
            StrictFlg = true;
        }
	}
}
