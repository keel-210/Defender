using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleSlider : MonoBehaviour
{
    [SerializeField]
    Image img;
    [SerializeField]
    Text tex;

    Vector2 UIpos;
    float deg;
    float Old_angle;
    void Start()
    {
        UIpos = Camera.main.WorldToScreenPoint(transform.position);
        //UIpos = new Vector2(UIpos.x, UIpos.y);
        Debug.Log(UIpos);
        deg = 0;
    }

    public void Drag()
    {
        if (Input.touchCount == 1)
        {
            Touch t = Input.touches[0];
            if (t.phase == TouchPhase.Moved)
            {
                var ray = GetComponentInParent<GraphicRaycaster>();

                
                Vector2 localPos; // Mouse position  
                RectTransformUtility.ScreenPointToLocalPointInRectangle(transform as RectTransform, Input.mousePosition, ray.eventCamera, out localPos);

                // local pos is the mouse position.
                float angle = (Mathf.Atan2(-localPos.y, localPos.x) * 180f / Mathf.PI + 180f) / 360f;
                float dir = angle - Old_angle;
                Old_angle = angle;
                deg += dir * 360;
                tex.text = deg.ToString();
            }
        }
    }
}
