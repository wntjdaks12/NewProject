using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// ���̽�ƽ Ȱ��ȭ/ ��Ȱ��ȭ���ִ� �г��Դϴ�.
/// </summary>
public class JoystickActivePanel : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
{
    /// <summary>
    /// �ش� ���̽�ƽ�Դϴ�.
    /// </summary>
    public GameObject target;
    // �ش� ���̽�ƽ�� ��Ʈ Ʈ�������Դϴ�.
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
    /// Ŭ�� ���� �� ȣ���մϴ�.
    /// </summary>
    /// <param name="eventData">Ŭ���� ���� �̺�Ʈ ������</param>
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!(targetRectTs || target))
            return;

        // �ش� ���̽�ƽ�� Ŭ���� ��ġ�� ����ݴϴ�.
        targetRectTs.anchoredPosition = new Vector2(eventData.position.x * 1920 / Screen.width, eventData.position.y * 1080 / Screen.height);

        // �ش� ���̽�ƽ�� Ȱ��ȭ��ŵ�ϴ�.
        target.SetActive(true);

        // �ش� ���̽�ƽ�� �޼ҵ带 �����ŵ�ϴ�.
        ExecuteEvents.Execute(target, eventData, ExecuteEvents.pointerDownHandler);
    }

    /// <summary>
    /// Ŭ�� ���� �� ȣ���մϴ�.
    /// </summary>
    /// <param name="eventData">Ŭ���� ���� �̺�Ʈ ������</param>
    public void OnPointerUp(PointerEventData eventData)
    {
        if (!target)
            return;

        // �ش� ���̽�ƽ�� �޼ҵ带 �����ŵ�ϴ�.
        ExecuteEvents.Execute(target, eventData, ExecuteEvents.pointerUpHandler);

        // �ش� ���̽�ƽ�� ��Ȱ��ȭ��ŵ�ϴ�.
        target.SetActive(false);
    }

    /// <summary>
    /// Ŭ�� �� ������ �� ȣ���մϴ�.
    /// </summary>
    /// <param name="eventData">Ŭ���� ���� �̺�Ʈ ������</param>
    public void OnDrag(PointerEventData eventData)
    {
        ExecuteEvents.Execute(target, eventData, ExecuteEvents.dragHandler);
    }
}