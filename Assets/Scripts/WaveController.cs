using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaveController : MonoBehaviour
{
    public List<WaveAndTime> WAT = new List<WaveAndTime>();
    List<PrefabListEmitter> Waves = new List<PrefabListEmitter>();
    public int WaveNumber { get; set; }

    PrefabListEmitter CurrentWave;
    WaveAndTime CurrentObj;
    float Timer;
    bool Activate;
    int MaxWave;
    void Start()
    {
        WaveNumber = 0;
        foreach (WaveAndTime x in WAT)
        {
            Waves.Add(x.PrefabList.GetComponent<PrefabListEmitter>());
        }
        MaxWave = WAT.Count - 1;
    }

    void FixedUpdate()
    {
        if (!Activate)
        {
            CurrentWave = Waves[WaveNumber];
            CurrentObj = WAT[WaveNumber];
            CurrentWave.Set();
            Activate = true;
        }
        CurrentWave.Emit();
        if (CurrentWave.list.Count == 0 && CurrentObj.PrefabList.transform.childCount == 0)
        {
            Timer += Time.deltaTime;
            if (Timer > CurrentObj.Time && WaveNumber < MaxWave)
            {
                WaveNumber++;
                Activate = false;
                Timer = 0;
            }
        }
    }
    [Serializable]
    public class WaveAndTime
    {
        public GameObject PrefabList;
        public float Time;
    }
}
