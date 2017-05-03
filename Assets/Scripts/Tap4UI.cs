using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap4UI : MonoBehaviour
{
    [SerializeField]
    LayerMask layermask;
	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (Input.touchCount > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                var ray = Camera.main.ScreenPointToRay(Input.touches[0].rawPosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit,layermask))
                {
                    InputPanel ip = hit.transform.GetComponent<InputPanel>();
                    ip.OnTap();
                }
            }
        }
	}
}
