using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// 화면을 드래그할 패널입니다.
public class DragPnl : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public DragPnlData data;

    // 처음으로 터치한 포지션입니다.
    private Vector2 startTouchPos;

    private void Awake() => data.dragValue = Vector2.zero;

    public void OnDrag(PointerEventData eventData)
    {
        // 최솟값, 최댓값에 따른 드래그할 값을 저장합니다.
        var pos = data.dragValue = startTouchPos - eventData.position;
        data.dragValue = new Vector2(Mathf.Clamp(pos.x, data.dragMin.x, data.dragMax.x), Mathf.Clamp(pos.y, data.dragMin.y, data.dragMax.y));
    }

    // 처음으로 터치 시 포지션을 저장합니다.
    public void OnPointerDown(PointerEventData eventData) => startTouchPos = eventData.position + data.dragValue;
}
