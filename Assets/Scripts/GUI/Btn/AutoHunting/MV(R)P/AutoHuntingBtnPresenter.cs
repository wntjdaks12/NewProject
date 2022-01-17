using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

/// <summary>
/// �ڵ� ��� ��ư�� �����͸� ������ �ִ� �Ű����Դϴ�. 
/// </summary>
public class AutoHuntingBtnPresenter : MonoBehaviour
{
    // �ڵ� ��� �������Դϴ�.
    private AutoHuntingModel model;

    // ��ư�� ���� �����Դϴ�.
    private AutoHuntingBtnState state;

    // ��ư �̹����Դϴ�.
    [SerializeField]
    private Image img;

    private void Awake()
    {
        model = new AutoHuntingModel();

        state = new AutoHuntingBtnOffState();
    }

    private void Start()
    {
        if (img == null) return;

        // �ڵ� ����� ��� ��ư�� Ȱ��ȭ�ϴ� ��Ʈ���Դϴ�.
        model.AutoHuntingData.ObserveEveryValueChanged(data => data.isAuto)
            .Where(isAuto => isAuto)
            .Subscribe(_ => state?.On(this));

        // �ڵ� ����� �ƴ� ��� ��ư�� ��Ȱ��ȭ�ϴ� ��Ʈ���Դϴ�.
        model.AutoHuntingData.ObserveEveryValueChanged(data => data.isAuto)
            .Where(isAuto => !isAuto)
            .Subscribe(_ => state?.Off(this));
    }

    /// <summary>
    /// ��ư�� Ŭ���մϴ�.
    /// </summary>
    public void OnClick()
    {
        if (model != null && model.AutoHuntingData != null)
            model.AutoHuntingData.isAuto = !model.AutoHuntingData.isAuto;
    }

    /// <summary>
    /// ��ư �̹����Դϴ�.
    /// </summary>
    public Image Img { get => img; }

    /// <summary>
    /// ��ư�� ���� �����Դϴ�.
    /// </summary>
    public AutoHuntingBtnState State { set => state = value; }
}

