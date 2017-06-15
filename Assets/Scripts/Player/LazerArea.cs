using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LazerArea : MonoBehaviour
{
    [SerializeField, Tag]
    string EnemyTag;
    [SerializeField]
    Object Lazer;

    int EnemyNum;
    bool RayFlg = true;
    [SerializeField]
    float Range;
    public List<GameObject> list = new List<GameObject>();

    public GameObject TargetGO;
    Transform Target;
    Health health;
    LineRenderer lr;
    float Damage, Range4code;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
    }
    private void OnEnable()
    {
        lr.enabled = false;
    }
    void FixedUpdate()
    {
        RayFlg = EnemyNum > 0;
        if (EnemyNum > 0)
        {
            if (Target && TargetGO.activeInHierarchy)
            {
                if (Vector3.Magnitude(Target.position - transform.position) < Range4code)
                {
                    health.health -= Damage;
                    lr.SetPosition(0, transform.position);
                    lr.SetPosition(1, Target.position);
                    lr.enabled = true;
                }
                else
                {
                    lr.enabled = false;
                }
            }
            else if (Time.timeScale != 0)
            {
                EnemyFind();
            }
        }
        else
        {
            lr.enabled = false;
        }
    }
    void EnemyFind()
    {
        if (list.Count > 0)
        {
            var l = list.Where(o => o.activeInHierarchy)
    .OrderBy(g => Vector3.Magnitude(g.transform.position - transform.position));
            if(l.Count() > 0)
            {
                TargetGO = l.First();
                Target = TargetGO.transform;
                health = TargetGO.GetComponent<Health>();
                Damage = GetComponent<Attack>().Damage;
                Range4code = transform.root.localScale.x * Range;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == EnemyTag)
        {
            list.Add(obj.gameObject);
            EnemyNum++;
        }
    }
    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.tag == EnemyTag)
        {
            list.Remove(obj.gameObject);
            EnemyNum--;
        }
    }
}
