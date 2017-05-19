using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour
{
    [SerializeField]
    float _Speed;
    public float Speed
    {
        get { return _Speed; }
        set { _Speed = value; }
    }
    [SerializeField]
    float SlowTime;
    [SerializeField, Tag]
    string Tag;
    [SerializeField]
    bool DontDestroy;
    List<EnemyController> list = new List<EnemyController>();
    void OnTriggerEnter2D(Collider2D obj)
    {
        EnemyController ec = obj.GetComponent<EnemyController>();
        list.Add(ec);
    }
    void OnTriggerExit2D(Collider2D obj)
    {
        EnemyController ec = obj.GetComponent<EnemyController>();

    }
    void OnTriggerStay2D(Collider2D obj)
    {
        if (obj.tag == Tag)
        {
            EnemyController ec = obj.GetComponent<EnemyController>();
            ec.Speed = Speed;
            if (!DontDestroy)
            {
                Destroy(gameObject);
            }
        }
    }
}
