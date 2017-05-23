using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerByTime : MonoBehaviour {
    [SerializeField]
    float Time;
    [SerializeField]
    RealTimeTimer timer;

    float realTime;
	void Start ()
    {
		
	}
	
	void Update ()
    {
        realTime = timer.Timer;
        if(realTime > Time)
        {

        }
	}
}