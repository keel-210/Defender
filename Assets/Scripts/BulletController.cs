using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    float Speed;
    [SerializeField, Tag]
    string Tag;
    [SerializeField]
    float RotLerp, VeloLerp;
    Rigidbody2D rb;
    Transform Target;
    Health health;
    void Start()
    {
        Target = GameObject.FindGameObjectsWithTag(Tag)
            .OrderBy(g => Vector3.Magnitude(g.transform.position - transform.position))
            .First().transform;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(this.DelayMethod(10, () =>
        {
            Destroy(gameObject);
        }));
        health = GetComponent<Health>();
    }

    void FixedUpdate()
    {
        if (Target)
        {
            Vector3 dir = Vector3.Normalize(Target.position - transform.position);
            rb.rotation = Mathf.Lerp(rb.rotation, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg, RotLerp);
            rb.velocity = Vector2.Lerp(rb.velocity, dir * Speed, VeloLerp);
        }
        if(health.health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
