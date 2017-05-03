using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChildInputPanel : InputPanel
{
    protected override void Tap(InputPanelName name)
    {
        switch (name)
        {
            case InputPanelName.Test: TestMethod(); break;
        }
    }
    public enum InputPanelName
    {
        Test
    }
    void TestMethod()
    {
        Debug.Log("TEST");
    }
}
