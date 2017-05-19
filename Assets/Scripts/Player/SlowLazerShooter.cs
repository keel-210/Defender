using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SlowLazerShooter : MonoBehaviour
{

    [SerializeField]
    float _Speed;
    public float Speed
    {
        get { return _Speed; }
        set { _Speed = value; }
    }

    [SerializeField, Tag]
    string Tag;
    [SerializeField]
    float Range;
    public GameObject TargetGO;
    Transform Target;
    EnemyController ec;
    LineRenderer lr;
    float Old_Speed;
    void Start()
    {
        EnemyFind();
        lr = GetComponent<LineRenderer>();
    }

    void FixedUpdate()
    {
        if (Vector3.Magnitude(Target.position - transform.position) < Range)
        {
            Old_Speed = ec.Speed;
            ec.Speed = Speed;
            lr.enabled = true;
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, Target.position);
        }
        else
        {
            ec.Speed = Old_Speed;

            lr.enabled = false;
        }

    }
    void EnemyFind()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(Tag);
        if (objs.Count() == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            TargetGO = objs
            .OrderBy(g => Vector3.Magnitude(g.transform.position - transform.position))
            .First();
            Target = TargetGO.transform;
            ec = TargetGO.GetComponent<EnemyController>();
        }
    }
}
