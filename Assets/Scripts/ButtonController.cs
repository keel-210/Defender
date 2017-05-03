using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public ButtonController button;
    [SerializeField]
    ChildButtonController.ButttonName butName;
#if UNITY_EDITOR
    Button but;
    void Reset()
    {
        but = GetComponent<Button>();
        UnityEditor.Events.UnityEventTools.RemovePersistentListener<GameObject>(but.onClick, OnClick);
        UnityEditor.Events.UnityEventTools.AddObjectPersistentListener<GameObject>(but.onClick, OnClick, gameObject);
    }
#endif
    void Start()
    {
        button = GameObject.Find("Canvas").transform.Find("ChildButtonController").GetComponent<ChildButtonController>();
    }
    public void OnClick(GameObject obj)
    {
        button.Click(butName);
    }

    protected virtual void Click(ChildButtonController.ButttonName buttonName)
    {
    }

    
}