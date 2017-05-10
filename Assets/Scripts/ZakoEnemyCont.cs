using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZakoEnemyCont : MonoBehaviour
{
    [SerializeField]
    float _Speed;
    public float Speed
    {
        get { return _Speed; }
        set { _Speed = value; }
    }
    public Health health { get; set; }

    Transform core;
    Rigidbody2D rb;
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        core = GameObject.Find("Core").transform;
	}
	void FixedUpdate()
    {
        Vector3 dir = Vector3.Normalize(core.position - transform.position);
        rb.velocity = dir * Speed;
        rb.rotation = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
    }
	void Update ()
    {
		
	}
}
