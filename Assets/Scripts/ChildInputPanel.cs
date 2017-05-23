using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChildInputPanel : InputPanel
{
    [SerializeField]
    UnityEngine.Object turret1, LTurret, MTurret, PTurret, Wall, HPTurret, SATurret;
    protected override void Tap(InputPanelName name)
    {
        switch (name)
        {
            case InputPanelName.Test: TestMethod(); break;
            case InputPanelName.Turret1: InitTurret(turret1); break;
            case InputPanelName.LazerTurret: InitTurret(LTurret); break;
            case InputPanelName.MissileTurret: InitTurret(MTurret); break;
            case InputPanelName.PulseTurret: InitTurret(PTurret); break;
            case InputPanelName.Wall: InitTurret(Wall); break;
            case InputPanelName.HealPulse: InitTurret(HPTurret); break;
            case InputPanelName.SlowArea: InitTurret(SATurret); break;
        }
    }
    public enum InputPanelName
    {
        Test, Turret1, LazerTurret, MissileTurret, PulseTurret, Wall, HealPulse, SlowArea
    }
    void TestMethod()
    {
        Debug.Log("TEST");
    }
    void InitTurret(UnityEngine.Object obj)
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
                pos = new Vector3(pos.x, pos.y, 0);
                Instantiate(obj, pos, Quaternion.identity);
                break;
            }
        }
    }
}
