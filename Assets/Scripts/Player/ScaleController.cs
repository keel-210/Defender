using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleController : MonoBehaviour
{
    [SerializeField]
    float Offset, MaxRange;
    Transform tra;
    void Start()
    {
        tra = transform;
    }
    private void OnDisable()
    {
        tra.localScale = new Vector3(1, 1, 1);
    }
    void FixedUpdate()
    {
        Vector3 scale = new Vector3(tra.localScale.x + Offset, tra.localScale.y + Offset, tra.localScale.z + Offset);
        tra.localScale = scale;
        if(tra.localScale.x > MaxRange)
        {
            gameObject.SetActive(false);
        }
    }
}
