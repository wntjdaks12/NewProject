using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// 플레이어를 컨트롤하는 조이스틱입니다.
/// </summary>
public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
{
    // 조이스틱의 렉트 트랜스폼을 가져옵니다.
    private RectTransform rectTs;

    // 조이스틱 핸들 부분의 렉트 트랜스폼을 가져옵니다.
    [SerializeField]
    private RectTransform handleRectTs;

    // 조이스틱 데이터를 참조합니다.
    [SerializeField]
    private JoystickData jStickData;

    private void Awake()
    {
        rectTs = GetComponent<RectTransform>();

        if (!jStickData)return;

        jStickData.PointerPosition = Vector2.zero;
        jStickData.IsTouching = false;
    }

    private void Start()
    {
        if (jStickData && handleRectTs)
            handleRectTs.anchoredPosition = jStickData.PointerPosition;
    }

    /// <summary>
    /// 클릭 후 움직일 때 호출합니다.
    /// </summary>
    /// <param name="eventData">클릭에 관련 이벤트 데이터</param>
    public void OnDrag(PointerEventData eventData)
    {
        if ((!rectTs || !handleRectTs) || !jStickData)
            return;

        // 조이스틱의 렉트 트랜스폼의 값을 음수, 양수의 값을 가진 사이즈로 만듭니다.
        var rectTsWidthHalf = rectTs.sizeDelta.x * 0.5f;

        // 단위 벡터로 만듭니다.
        jStickData.PointerPosition = (new Vector2(eventData.position.x * 1920 / Screen.width, eventData.position.y * 1080 / Screen.height) - rectTs.anchoredPosition) / (rectTsWidthHalf);

        // 핸들이 움직이는 범위((-1, -1) ~ (1, 1))를 지정하기 합니다.
        if (jStickData.PointerPosition.magnitude > 1)
            jStickData.PointerPosition = jStickData.PointerPosition.normalized;

        handleRectTs.anchoredPosition = jStickData.PointerPosition * rectTsWidthHalf;
    }

    /// <summary>
    /// 클릭 시작 시 호출합니다.
    /// </summary>
    /// <param name="eventData">클릭에 관련 이벤트 데이터</param>
    public void OnPointerDown(PointerEventData eventData)
    {
        if(jStickData)
            jStickData.IsTouching = true;

        OnDrag(eventData);
    }

    /// <summary>
    /// 클릭 끝날 시 호출합니다.
    /// </summary>
    /// <param name="eventData">클릭에 관련 이벤트 데이터</param>
    public void OnPointerUp(PointerEventData eventData)
    {
        if (!jStickData || !handleRectTs)
            return;

        // 핸들을 초기화합니다
        jStickData.PointerPosition = Vector2.zero;
        jStickData.IsTouching = false;

        handleRectTs.anchoredPosition = jStickData.PointerPosition;
    }
}
