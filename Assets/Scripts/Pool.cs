using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pool : MonoBehaviour
{
    [SerializeField]
    Object prefab;
    [SerializeField]
    Transform tra;

    List<GameObject> list = new List<GameObject>();
    public GameObject Request()
    {
        bool InitFlg = false;
        GameObject returnObj = null;
        foreach (GameObject g in list)
        {
            if (!g.activeInHierarchy)
            {
                g.SetActive(true);
                g.transform.parent = tra;
                returnObj = g;
                InitFlg = true;
                break;
            }
        }
        if (!InitFlg)
        {
            GameObject x = (GameObject)Instantiate(prefab);
            list.Add(x);
            returnObj = x;
        }
        return returnObj;
    }
    public void DestroyRequest(GameObject go)
    {
        go.transform.parent = transform;
        go.SetActive(false);
    }
}
