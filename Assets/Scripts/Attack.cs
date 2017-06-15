using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    float _Damage;
    public float Damage
    {
        get { return _Damage; }
        set { _Damage = value; }
    }
    [SerializeField, Tag]
    string Tag;
    [SerializeField]
    bool DontDestroy, CollisionUnable;

    Health health;
    private void Start()
    {
        health = GetComponent<Health>();
    }
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (!CollisionUnable)
        {
            if (obj.tag == Tag)
            {
                obj.GetComponent<Health>().health -= Damage;
                if (!DontDestroy)
                {
                    health.health = 0;
                }
            }
        }
    }
}
