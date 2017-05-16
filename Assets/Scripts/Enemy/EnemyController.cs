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
    void Awake()
    {
        health = GetComponent<Health>();
    }
}

