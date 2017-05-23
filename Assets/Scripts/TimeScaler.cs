using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaler : MonoBehaviour
{
    [SerializeField]
    CircleSlider CS;

    float Value, Old_Value;
    void Update()
    {
        Value = CS.value;
        if (Value != Old_Value)
        {
            Time.timeScale = Value;
        }
        Old_Value = Value;
    }
}
