using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 조이스틱 활성화/ 비활성화해주는 패널입니다.
/// </summary>
public class JoystickActivePanel : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
{
    /// <summary>
    /// 해당 조이스틱입니다.
    /// </summary>
    public GameObject target;
    // 해당 조이스틱의 렉트 트랜스폼입니다.
    private RectTransform targetRectTs;

    private void Awake()
    {
        if (!target)
            return;

        targetRectTs = target.GetComponent<RectTransform>();
    }

    private void Start()
    {
        if (target)
            target.SetActive(false);
    }

    /// <summary>
    /// 클릭 시작 시 호출합니다.
    /// </summary>
    /// <param name="eventData">클릭에 관련 이벤트 데이터</param>
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!(targetRectTs || target))
            return;

        // 해당 조이스틱을 클릭한 위치로 잡아줍니다.
        targetRectTs.anchoredPosition = new Vector2(eventData.position.x * 1920 / Screen.width, eventData.position.y * 1080 / Screen.height);

        // 해당 조이스틱을 활성화시킵니다.
        target.SetActive(true);

        // 해당 조이스틱의 메소드를 실행시킵니다.
        ExecuteEvents.Execute(target, eventData, ExecuteEvents.pointerDownHandler);
    }

    /// <summary>
    /// 클릭 끝날 시 호출합니다.
    /// </summary>
    /// <param name="eventData">클릭에 관련 이벤트 데이터</param>
    public void OnPointerUp(PointerEventData eventData)
    {
        if (!target)
            return;

        // 해당 조이스틱의 메소드를 실행시킵니다.
        ExecuteEvents.Execute(target, eventData, ExecuteEvents.pointerUpHandler);

        // 해당 조이스틱을 비활성화시킵니다.
        target.SetActive(false);
    }

    /// <summary>
    /// 클릭 후 움직일 때 호출합니다.
    /// </summary>
    /// <param name="eventData">클릭에 관련 이벤트 데이터</param>
    public void OnDrag(PointerEventData eventData)
    {
        ExecuteEvents.Execute(target, eventData, ExecuteEvents.dragHandler);
    }
}