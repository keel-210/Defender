using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[RequireComponent(typeof(LineRenderer))]
public class LazerShooter : MonoBehaviour
{
    [SerializeField, Tag]
    string Tag;
    [SerializeField]
    float Range;
    public GameObject TargetGO;
    Transform Target;
    Health health;
    LineRenderer lr;
    float Damage;
    void Start()
    {
        EnemyFind();
        lr = GetComponent<LineRenderer>();
    }

    void FixedUpdate()
    {
        if (Target && TargetGO.activeInHierarchy)
        {
            if (Vector3.Magnitude(Target.position - transform.position) < Range)
            {
                health.health -= Damage;
                lr.enabled = true;
                lr.SetPosition(0, transform.position);
                lr.SetPosition(1, Target.position);
            }
            else
            {
                lr.enabled = false;
            }
        }
        else
        {
            EnemyFind();
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
            .Where(o => o.activeInHierarchy)
            .OrderBy(g => Vector3.Magnitude(g.transform.position - transform.position))
            .First();
            Target = TargetGO.transform;
            health = TargetGO.GetComponent<Health>();
            Damage = GetComponent<Attack>().Damage;
        }
    }
}
