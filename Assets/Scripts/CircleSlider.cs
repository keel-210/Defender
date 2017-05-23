using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleSlider : MonoBehaviour
{
    [SerializeField]
    Image Handle;
    [SerializeField]
    Text tex;
    [SerializeField]
    float MaxValue;
    public float value;

    float deg;
    float Old_angle;
    void Start()
    {
        deg = value/360f;
        tex.text = ((int)(360 * deg)).ToString();
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
                RectTransformUtility.ScreenPointToLocalPointInRectangle(Handle.transform as RectTransform, t.position, ray.eventCamera, out localPos);

                // local pos is the mouse position.
                float angle = (Mathf.Atan2(-localPos.y, localPos.x) * 180f / Mathf.PI + 180f) / 360f;
                float dir = angle - Old_angle;
                if (Mathf.Abs(dir) > 0.1f)
                {
                    dir = 0;
                }
                Old_angle = angle;
                deg = Mathf.Clamp(deg + dir, 0, 1);
                Handle.fillAmount = deg;
                value = deg * MaxValue;
                tex.text = ((int)(value)).ToString();
            }
        }
    }
}
