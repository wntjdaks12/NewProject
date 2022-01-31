using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// ȭ���� �巡���� �г��Դϴ�.
public class DragPnl : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public DragPnlData data;

    // ó������ ��ġ�� �������Դϴ�.
    private Vector2 startTouchPos;

    private void Awake() => data.dragValue = Vector2.zero;

    public void OnDrag(PointerEventData eventData)
    {
        // �ּڰ�, �ִ񰪿� ���� �巡���� ���� �����մϴ�.
        var pos = data.dragValue = startTouchPos - eventData.position;
        data.dragValue = new Vector2(Mathf.Clamp(pos.x, data.dragMin.x, data.dragMax.x), Mathf.Clamp(pos.y, data.dragMin.y, data.dragMax.y));
    }

    // ó������ ��ġ �� �������� �����մϴ�.
    public void OnPointerDown(PointerEventData eventData) => startTouchPos = eventData.position + data.dragValue;
}
