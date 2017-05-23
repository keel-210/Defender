using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSetter : MonoBehaviour {
    [SerializeField]
    RealTimeTimer timer;

    float value;
    Text text;
	void Start ()
    {
        text = GetComponent<Text>();
	}
	
	void Update ()
    {
        value = timer.Timer;
        text.text = value.ToString();
	}
}

