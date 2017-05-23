using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaveController : MonoBehaviour
{
    public int WaveNumber { get; set; }

    [SerializeField]
    UnityEngine.Object Zako;
    public Transform WaveObj;
    PrefabListEmitter Wave;
    bool Activate;
    int MaxWave, NextWave;
    float IntervalTime, WaveFinishTime;
    void Start()
    {
        WaveNumber = 0;
        Wave = WaveObj.GetComponent<PrefabListEmitter>();
    }

    void FixedUpdate()
    {
        if (!Activate)
        {
            Wave.Set();
            Activate = true;
            WaveFinishTime = 0;
        }
        WaveFinishTime += Time.deltaTime;
        Wave.Emit();
        if (Wave.list.Count == 0 && WaveObj.childCount == 0)
        {
            WaveNumber++;
            WaveMaker(WaveNumber, WaveFinishTime);
            Activate = true;
        }
    }
    void WaveMaker(int WaveNum, float FinishTime)
    {
        PrefabListEmitter.EmitPrefab prefab = new PrefabListEmitter.EmitPrefab { Time = 0.1f, Prefab = Zako, Pos = new Vector3(10, -2, 0) };
        for (int i = 0; i < WaveNum; i++)
        {
            Wave.list.Add(prefab);
        }
    }

}
