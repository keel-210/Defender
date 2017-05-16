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
    [SerializeField]
    bool Area4Ray;

    GameObject Obj4Ray;
    int EnemyNum;
    float Timer;
    bool RayFlg = true;
    void Start()
    {

    }
    void FixedUpdate()
    {
        if (EnemyNum > 0)
        {
            Timer += Time.deltaTime;
            if (Timer > InitTime && !Area4Ray)
            {
                Instantiate(Burret, transform.position, Quaternion.identity);
                Timer = 0;
            }
            if (Area4Ray && RayFlg)
            {
                Obj4Ray = (GameObject)Instantiate(Burret, transform.position, Quaternion.identity);
                RayFlg = false;
            }
        }
        else
        {
            Timer = 0;
            if (Area4Ray)
            {
                RayFlg = true;
            }
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
