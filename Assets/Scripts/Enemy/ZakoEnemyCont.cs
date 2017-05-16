using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZakoEnemyCont : EnemyController
{
    [SerializeField]
    float _Speed;
    public float Speed
    {
        get { return _Speed; }
        set { _Speed = value; }
    }
    [SerializeField, Tag]
    string PlayerTag;
    [SerializeField]
    float AttackTime;
    [SerializeField]
    Object EnemyBullet;
    Transform core,turret;
    Rigidbody2D rb;
    bool Attacking;
    float Timer4Attack;
    delegate void DeathCheck();
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        core = GameObject.Find("Core").transform;
	}
	void FixedUpdate()
    {
        if(health.health > 0)
        {
            if (Attacking)
            {
                if (turret)
                {
                    Vector3 dir = Vector3.Normalize(turret.position - transform.position);
                    rb.velocity = dir * Speed;
                    rb.rotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                }
                Timer4Attack += Time.deltaTime;
                if (Timer4Attack > AttackTime)
                {
                    Instantiate(EnemyBullet, transform.position, transform.rotation);
                    Timer4Attack = 0;
                }
            }
            else
            {
                Vector3 dir = Vector3.Normalize(core.position - transform.position);
                rb.velocity = dir * Speed;
                rb.rotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            }
        }
        else
        {
            rb.velocity = new Vector2(1000, 1000);
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D obj)
    {
        if(obj.collider.tag == PlayerTag)
        {
            Attacking = true;
            rb.velocity = Vector2.zero;
            turret = obj.transform;
        }
    }
    void OnCollisionExit2D(Collision2D obj)
    {
        if (obj.collider.tag == PlayerTag)
        {
            Attacking = false;
        }
    }
}
