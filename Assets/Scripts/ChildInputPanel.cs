using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChildInputPanel : InputPanel
{
    [SerializeField]
    UnityEngine.Object turret1;
    protected override void Tap(InputPanelName name)
    {
        switch (name)
        {
            case InputPanelName.Test: TestMethod(); break;
            case InputPanelName.Turret1: Turret1Method(); break;
        }
    }
    public enum InputPanelName
    {
        Test,Turret1,
    }
    void TestMethod()
    {
        Debug.Log("TEST");
    }
    void Turret1Method()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
                pos = new Vector3(pos.x, pos.y, 0);
                Instantiate(turret1, pos, Quaternion.identity);
                break;
            }
        }
    }
}
