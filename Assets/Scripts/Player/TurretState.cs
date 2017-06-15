using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretState : MonoBehaviour
{
    [SerializeField]
    GameObject Turret;
    [SerializeField, Tag]
    string PlayerTag;
    [SerializeField]
    float shrinkRate,shrinkTime;

    public bool TurretCollision { get; set; }
    bool CanSetTurret,EffectFlg;
    Coroutine EffectCor;
    SpriteRenderer sr;
    Color c;
    float NextSize;
    void Awake()
    {
        WaveController wc = GameObject.Find("WaveController").GetComponent<WaveController>();
        wc.Turrets.Add(this);
        sr = GetComponent<SpriteRenderer>();
        c = sr.color;
        NextSize = transform.localScale.x;
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
    public void WaveClear()
    {
        float rate = (NextSize - NextSize * shrinkRate) / shrinkTime;
        NextSize *= shrinkRate;
        if (EffectCor != null)
        {
            StopCoroutine(EffectCor);
        }
        EffectCor = StartCoroutine(ShrinkEffect(shrinkRate,shrinkTime));
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
    IEnumerator ShrinkEffect(float rate,float waittime)
    {
        transform.localScale -= new Vector3(1, 1, 1) * rate * Time.deltaTime;
        yield return new WaitForSeconds(waittime);
    }
    public void ReStart()
    {
        transform.localScale = new Vector3(1, 1, 1);
        if (EffectCor != null)
        {
            StopCoroutine(EffectCor);
        }
    }
}
