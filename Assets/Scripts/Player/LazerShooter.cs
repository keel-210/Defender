using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[RequireComponent(typeof(LineRenderer))]
public class LazerShooter : MonoBehaviour
{
    [SerializeField, Tag]
    string Tag;

    float Range;
    public GameObject TargetGO;
    Transform Target;
    Health health;
    LineRenderer lr;
    float Damage;
    void Awake()
    {
        EnemyFind();
        lr = GetComponent<LineRenderer>();
    }
    private void OnEnable()
    {
        lr.enabled = false;
    }
    void FixedUpdate()
    {
        if (Target && TargetGO.activeInHierarchy)
        {
            if (Vector3.Magnitude(Target.position - transform.position) < Range)
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
        else
        {
            EnemyFind();
        }
    }
    void EnemyFind()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(Tag);
        if (objs.Count() != 0)
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
