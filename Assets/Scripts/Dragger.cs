using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragger : MonoBehaviour
{
    int ID;
    Transform tra;
    bool Moving;
    
    //ForTouchInput
    void Update()
    {
        if(Input.touchCount == 1)
        {
            Touch t = Input.touches[0];
            if (!Moving)
            {
                if (t.phase == TouchPhase.Began)
                {
                    var ray = Camera.main.ScreenPointToRay(t.position);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        ID = t.fingerId;
                        Moving = true;
                        tra = hit.transform;
                    }
                }
            }
            else
            {
                if (t.phase == TouchPhase.Ended || t.fingerId != ID)
                {
                    Moving = false;
                    tra = null;
                }
                if (t.phase == TouchPhase.Moved)
                {
                    if (Moving)
                    {
                        var pos = Camera.main.ScreenToWorldPoint(t.position);
                        pos = new Vector3(pos.x, pos.y, 0);
                        tra.position = pos;
                    }
                }
            }
        }
    }
}