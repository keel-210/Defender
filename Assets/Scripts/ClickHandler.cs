using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private ClickEvent clickHandler;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("run");
        //this.clickHandler.Invoke(this.gameObject);
    }

    public void AddClickHandler(UnityAction<GameObject> handler)
    {
        this.clickHandler.AddListener(handler);
    }

    [System.Serializable]
    public class ClickEvent : UnityEvent<GameObject> { }
}