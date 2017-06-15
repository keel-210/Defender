using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretArea : MonoBehaviour
{
    [SerializeField, Tag]
    string EnemyTag;
    [SerializeField]
    Object Burret;
    [SerializeField]
    float InitTime;

    Pool pool;
    int EnemyNum;
    float Timer;
    void Start()
    {
        pool = GameObject.Find("Pools").transform.Find(Burret.name).gameObject.GetComponent<Pool>();
    }
    void FixedUpdate()
    {
        if (EnemyNum > 0)
        {
            Timer += Time.deltaTime;
            if (Timer > InitTime)
            {
                GameObject obj = pool.Request(transform);
                obj.transform.position = transform.position;
                Timer = 0;
            }
        }
        else
        {
            Timer = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == EnemyTag)
        {
            EnemyNum++;
        }
    }
    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.tag == EnemyTag)
        {
            EnemyNum--;
        }
    }
}
