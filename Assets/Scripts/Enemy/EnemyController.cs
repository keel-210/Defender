using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    Health _health;
    public Health health
    {
        get { return _health; }
        set { _health = value; }
    }
    [SerializeField]
    float _Speed;
    public float Speed
    {
        get { return _Speed; }
        set { _Speed = value; }
    }
    void Awake()
    {
        health = GetComponent<Health>();
    }
}

