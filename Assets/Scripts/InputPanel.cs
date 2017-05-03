using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class InputPanel : MonoBehaviour
{
    [SerializeField]
    ChildInputPanel.InputPanelName Name;
    InputPanel inputPanel;
    void Start()
    {
        inputPanel = GameObject.Find("Canvas").transform.Find("ChildInputPanel").GetComponent<ChildInputPanel>();
    }
    public void OnTap()
    {
        inputPanel.Tap(Name);
    }
    protected virtual void Tap(ChildInputPanel.InputPanelName name)
    {
    }
}
