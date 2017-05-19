using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SlowArea : MonoBehaviour
{
    [SerializeField]
    float _Speed;
    public float Speed
    {
        get { return _Speed; }
        set { _Speed = value; }
    }
    [SerializeField, Tag]
    string Tag;

    List<EneAndSpeed> list = new List<EneAndSpeed>();
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == Tag)
        {
            EnemyController ec = obj.GetComponent<EnemyController>();
            list.Add(new EneAndSpeed { EC = ec, Speed = ec.Speed });
            ec.Speed = Speed;
        }
    }
    void OnTriggerExit2D(Collider2D obj)
    {
        if(obj.tag == Tag)
        {
            EnemyController ec = obj.GetComponent<EnemyController>();
            var x = list.Where(l => l.EC).Where(EC => EC.EC == ec).ToList();
            ec.Speed = x.First().Speed;
            list.Remove(x.First());
        }
    }
    class EneAndSpeed
    {
        public EnemyController EC { get; set; }
        public float Speed { get; set; }
    }
}
