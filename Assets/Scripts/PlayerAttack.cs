using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    float _Attack;
    public float Attack
    {
        get { return _Attack; }
        set { _Attack = value; }
    }

    [SerializeField,Tag]
    string EnemyTag;
    [SerializeField]
    Object Burret;

    int EnemyNum;
    float Timer;
	void Start ()
    {
		
	}
	void FixedUpdate()
    {
        if (EnemyNum > 0)
        {
            Timer += Time.deltaTime;
            if (Timer > 0.5f)
            {
                GameObject obj = (GameObject)Instantiate(Burret, transform.position, Quaternion.identity);
                obj.GetComponent<BulletController>().Attack = Attack;
                Timer = 0;
            }
        }
        else
        {
            Timer = 0;
        }
    }

	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.tag == EnemyTag)
        {
            Debug.Log("Enter");
            EnemyNum++;
        }
    }
    void OnTriggerExit2D(Collider2D obj)
    {
        if(obj.tag == EnemyTag)
        {
            EnemyNum--;
        }
    }
}
