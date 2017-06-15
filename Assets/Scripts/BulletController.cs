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
        GameObject[] objs = GameObject.FindGameObjectsWithTag(Tag);
        if (objs.Count() != 0)
        {
            Target = objs
            .Where(o => o.activeInHierarchy)
            .OrderBy(g => Vector3.Magnitude(g.transform.position - transform.position))
            .First().transform;
        }
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(this.DelayMethod(10, () =>
        {
            gameObject.SetActive(false);
        }));
        health = GetComponent<Health>();
    }
    private void OnDisable()
    {
        health.health = 1;
    }
    void FixedUpdate()
    {
        if (Target.gameObject.activeInHierarchy)
        {
            Vector3 dir = Vector3.Normalize(Target.position - transform.position);
            rb.rotation = Mathf.Lerp(rb.rotation, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg, RotLerp);
            rb.velocity = Vector2.Lerp(rb.velocity, dir * Speed, VeloLerp);
        }
        if(health.health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
