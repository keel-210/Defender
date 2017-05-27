using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public int WaveNumber { get; set; }

    public Transform WaveObj;
    PrefabListEmitter Wave;
    PrefabListEmitter.EmitPrefab prefab = new PrefabListEmitter.EmitPrefab();
    bool Activate;
    int MaxEnemyNum = 15;
    void Start()
    {
        WaveNumber = 0;
        Wave = WaveObj.GetComponent<PrefabListEmitter>();
        Activate = true;
    }

    void FixedUpdate()
    {
        if (Activate)
        {
            Wave.Emit();
        }

        if (Wave.list.Count == 0 && WaveObj.childCount == 0)
        {
            WaveNumber++;
            WaveMaker(WaveNumber);
            Activate = true;
        }
    }
    void WaveMaker(int WaveNum)
    {
        if(WaveNum > MaxEnemyNum)
        {
            WaveNum = MaxEnemyNum;
        }
        for (int i = 0; i < WaveNum; i++)
        {
            prefab.Time = 0.1f;
            prefab.Pos = 10 * new Vector3(Random.value - 0.5f, Random.value - 0.5f, 0);
            Wave.list.Add(prefab);
        }
    }

}
