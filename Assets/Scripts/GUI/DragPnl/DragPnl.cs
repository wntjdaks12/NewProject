using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragPnl : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public DragPnlData data;

    private Vector2 startPos;

    private void Awake() => data.dragPosition = Vector2.zero;

    public void OnDrag(PointerEventData eventData) => data.dragPosition = startPos - eventData.position;

    public void OnPointerDown(PointerEventData eventData) => startPos = eventData.position + data.dragPosition;
}
