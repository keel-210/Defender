using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaveController : MonoBehaviour
{
    public List<TurretState> Turrets = new List<TurretState>();
    public Transform WaveObj;
    public int WaveNumber { get; set; }
    [SerializeField]
    float rimit, EffectTime, StrictTime;
    [SerializeField]
    RealTimeTimer timer;
    [SerializeField]
    GameObject panel, ReButton;

    PrefabListEmitter Wave;
    PrefabListEmitter.EmitPrefab prefab = new PrefabListEmitter.EmitPrefab();
    Coroutine WaveClearEffectCor;
    bool Activate, EffectFlg, StrictFlg;
    int MaxEnemyNum = 15;
    float rate, rim4rate, Old_TimeScale;
    Vector3 Scale = new Vector3(1, 1, 1);
    void Start()
    {
        WaveNumber = 0;
        Wave = WaveObj.GetComponent<PrefabListEmitter>();
        rim4rate = 1;
        prefab.Time = 0;
        prefab.Pos = new Vector3(0, 7, 0);
        Wave.list.Add(prefab);
        Activate = true;
        EffectFlg = false;
        StrictFlg = false;
        panel.SetActive(false);
        ReButton.SetActive(false);
    }

    void FixedUpdate()
    {
        if (!Activate && Wave.list.Count == 0 && WaveObj.childCount == 0)
        {
            WaveClear();
        }
        if (Activate)
        {
            Wave.Emit();
            if (Wave.list.Count == 0)
            {
                Activate = false;
            }
        }
        TimeStrict();
    }
    void WaveMaker(int WaveNum)
    {
        if (WaveNum > MaxEnemyNum)
        {
            WaveNum = MaxEnemyNum;
        }
        Vector3 dir = new Vector3(Random.value - 0.5f, Random.value - 0.5f, 0);
        for (int i = 0; i < WaveNum; i++)
        {
            prefab = new PrefabListEmitter.EmitPrefab();
            prefab.Time = Random.Range(0, 0.5f);
            Vector3 d = new Vector3(dir.x, dir.y * i, 0).normalized;
            prefab.Pos = 10 * d;
            Wave.list.Add(prefab);
        }
    }
    void WaveClear()
    {
        WaveNumber++;
        WaveMaker(WaveNumber);
        Activate = true;
        foreach(TurretState t in Turrets)
        {
            t.WaveClear();
        }
    }
    public void TimeStrict()
    {
        if (timer.Timer > StrictTime && !StrictFlg)
        {
            timer.Stop();
            Old_TimeScale = Time.timeScale;
            Time.timeScale = 0;
            StrictFlg = true;
            panel.SetActive(true);
            ReButton.SetActive(true);
            foreach(Transform zako in transform.GetChild(0).transform)
            {
                zako.gameObject.SetActive(false);
            }
            foreach (TurretState t in Turrets)
            {
                t.ReStart();
            }
        }
    }
    public void WaveRestart()
    {
        timer.Reset();
        Time.timeScale = Old_TimeScale;
        Start();
    }
}
