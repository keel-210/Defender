using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZakoEnemyCont : EnemyController
{
    Transform core;
    Rigidbody2D rb;
    [SerializeField]
    float DefaltHealth;
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        core = GameObject.Find("Core").transform;
	}
    private void OnDisable()
    {
        health.health = DefaltHealth;
    }
    void FixedUpdate()
    {
        if(health.health > 0)
        {
                Vector3 dir = Vector3.Normalize(core.position - transform.position);
                rb.velocity = dir * Speed;
                rb.rotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        }
        else
        {
            rb.velocity = new Vector2(1000, 1000);
            gameObject.SetActive(false);
        }
    }
}
