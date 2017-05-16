using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    float _health;
    public float health
    {
        get { return _health; }
        set
        {
            _health = Mathf.Min(MaxHealth, Mathf.Max(0, value));
        }
    }
    float MaxHealth;
    void Start()
    {
        MaxHealth = _health;
    }
}
