using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BulletController : MonoBehaviour
{
    public float Attack { get; set; }
    [SerializeField]
    float Speed;
    [SerializeField, Tag]
    string EnemyTag;
    Rigidbody2D rb;
    Transform Target;
    void Start()
    {
        Target = GameObject.FindGameObjectsWithTag(EnemyTag)
            .OrderBy(g => Vector3.Magnitude(g.transform.position - transform.position))
            .First().transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 dir = Vector3.Normalize(Target.position - transform.position);
        rb.rotation = Mathf.Lerp(rb.rotation, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg, 0.1f);
        rb.velocity = transform.right * Speed;
    }
}
