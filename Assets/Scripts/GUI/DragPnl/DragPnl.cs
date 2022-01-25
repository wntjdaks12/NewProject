using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragPnl : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public DragPnlData data;

    private Vector2 startPos;

    private void Awake() => data.dragPosition = Vector2.zero;

    public void OnDrag(PointerEventData eventData)
    {
        var pos = data.dragPosition = startPos - eventData.position;
        data.dragPosition = new Vector2(Mathf.Clamp(pos.x, data.dragMin.x, data.dragMax.x), Mathf.Clamp(pos.y, data.dragMin.y, data.dragMax.y));
    }

    public void OnPointerDown(PointerEventData eventData) => startPos = eventData.position + data.dragPosition;
}
