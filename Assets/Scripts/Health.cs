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
        set { _health = value; }
    }
}
