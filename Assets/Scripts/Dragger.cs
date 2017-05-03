using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragger : MonoBehaviour
{
    [SerializeField]
    int ID;
    Transform tra;
    bool Moving;
    
    //ForTouchInput
    void Update()
    {
        if(Input.touchCount > 0)
        {
            if (!Moving)
            {
                if (Input.touches[ID].phase == TouchPhase.Began)
                {
                    var ray = Camera.main.ScreenPointToRay(Input.touches[ID].position);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        Moving = true;
                        tra = hit.transform;
                    }
                }
            }
            else
            {
                if (Input.touches[ID].phase == TouchPhase.Moved)
                {
                    if (Moving)
                    {
                        var pos = Camera.main.ScreenToWorldPoint(Input.touches[ID].position);
                        pos = new Vector3(pos.x, pos.y, 0);
                        tra.position = pos;
                    }
                }
                if (Input.touches[ID].phase == TouchPhase.Ended)
                {
                    Moving = false;
                    tra = null;
                }
            }
        }
    }
}