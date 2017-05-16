using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChildInputPanel : InputPanel
{
    [SerializeField]
    UnityEngine.Object turret1,LTurret,MTurret,PTurret;
    protected override void Tap(InputPanelName name)
    {
        switch (name)
        {
            case InputPanelName.Test: TestMethod(); break;
            case InputPanelName.Turret1: Turret1Method(); break;
            case InputPanelName.LazerTurret: LazerTurretInit(); break;
            case InputPanelName.MissileTurret: MissileTurretInit(); break;
            case InputPanelName.PulseTurret: PulseTurretInit(); break;
        }
    }
    public enum InputPanelName
    {
        Test, Turret1, LazerTurret, MissileTurret, PulseTurret
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
    void LazerTurretInit()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
                pos = new Vector3(pos.x, pos.y, 0);
                Instantiate(LTurret, pos, Quaternion.identity);
                break;
            }
        }
    }
    void MissileTurretInit()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
                pos = new Vector3(pos.x, pos.y, 0);
                Instantiate(MTurret, pos, Quaternion.identity);
                break;
            }
        }
    }
    void PulseTurretInit()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
                pos = new Vector3(pos.x, pos.y, 0);
                Instantiate(PTurret, pos, Quaternion.identity);
                break;
            }
        }
    }
}
