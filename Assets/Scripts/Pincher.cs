using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Pincher : MonoBehaviour
{
    Transform tra;
    Quaternion rot;
    bool Rotating;
    void Update()
    {
        if (Input.touchCount == 2)
        {
            if (!Rotating)
            {
                var ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Rotating = true;
                    tra = hit.transform;
                    rot = tra.rotation;
                }
            }
            else
            {
                if (Input.touches[1].phase == TouchPhase.Moved)
                {
                    Vector3 dir = Input.touches[1].position - Input.touches[0].position;
                    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    tra.rotation = Quaternion.Slerp(tra.rotation, rot * Quaternion.Euler(0, 0, angle), 0.5f);
                }
            }
        }
    }
}

