using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// �÷��̾ ��Ʈ���ϴ� ���̽�ƽ�Դϴ�.
/// </summary>
public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
{
    // ���̽�ƽ�� ��Ʈ Ʈ�������� �����ɴϴ�.
    private RectTransform rectTs;

    // ���̽�ƽ �ڵ� �κ��� ��Ʈ Ʈ�������� �����ɴϴ�.
    [SerializeField]
    private RectTransform handleRectTs;

    // ���̽�ƽ �����͸� �����մϴ�.
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
    /// Ŭ�� �� ������ �� ȣ���մϴ�.
    /// </summary>
    /// <param name="eventData">Ŭ���� ���� �̺�Ʈ ������</param>
    public void OnDrag(PointerEventData eventData)
    {
        if ((!rectTs || !handleRectTs) || !jStickData)
            return;

        // ���̽�ƽ�� ��Ʈ Ʈ�������� ���� ����, ����� ���� ���� ������� ����ϴ�.
        var rectTsWidthHalf = rectTs.sizeDelta.x * 0.5f;

        // ���� ���ͷ� ����ϴ�.
        jStickData.PointerPosition = (new Vector2(eventData.position.x * 1920 / Screen.width, eventData.position.y * 1080 / Screen.height) - rectTs.anchoredPosition) / (rectTsWidthHalf);

        // �ڵ��� �����̴� ����((-1, -1) ~ (1, 1))�� �����ϱ� �մϴ�.
        if (jStickData.PointerPosition.magnitude > 1)
            jStickData.PointerPosition = jStickData.PointerPosition.normalized;

        handleRectTs.anchoredPosition = jStickData.PointerPosition * rectTsWidthHalf;
    }

    /// <summary>
    /// Ŭ�� ���� �� ȣ���մϴ�.
    /// </summary>
    /// <param name="eventData">Ŭ���� ���� �̺�Ʈ ������</param>
    public void OnPointerDown(PointerEventData eventData)
    {
        if(jStickData)
            jStickData.IsTouching = true;

        OnDrag(eventData);
    }

    /// <summary>
    /// Ŭ�� ���� �� ȣ���մϴ�.
    /// </summary>
    /// <param name="eventData">Ŭ���� ���� �̺�Ʈ ������</param>
    public void OnPointerUp(PointerEventData eventData)
    {
        if (!jStickData || !handleRectTs)
            return;

        // �ڵ��� �ʱ�ȭ�մϴ�
        jStickData.PointerPosition = Vector2.zero;
        jStickData.IsTouching = false;

        handleRectTs.anchoredPosition = jStickData.PointerPosition;
    }
}
