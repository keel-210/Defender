using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretState : MonoBehaviour
{
    [SerializeField]
    GameObject Turret;
    [SerializeField, Tag]
    string PlayerTag;

    public bool TurretCollision { get; set; }
    bool CanSetTurret;
    SpriteRenderer sr;
    Color c;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        c = sr.color;
    }
    public void Pick()
    {
        sr.color = new Color(1,1,1,0.4f);
        Turret.SetActive(false);
    }
	public void Release()
    {
        if (CanSetTurret)
        {
            sr.color = c;
            Turret.SetActive(true);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider obj)
    {
        if(obj.tag == PlayerTag && !Turret.activeInHierarchy)
        {
            UnableSet();
            TurretCollision = true;
        }
    }
    void OnTriggerExit(Collider obj)
    {
        if (obj.tag == PlayerTag && !Turret.activeInHierarchy)
        {
            EnableSet();
            TurretCollision = false;
        }
    }
    public void UnableSet()
    {
        sr.color = new Color(1, 0, 0, 0.4f);
        CanSetTurret = false;
    }
    public void EnableSet()
    {
        sr.color = new Color(1, 1, 1, 0.4f);
        CanSetTurret = true;
    }
}
