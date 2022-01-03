using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

/// <summary>
/// ��Ÿ�� ������ UGUI�� �����͸� ������ �ִ� �Ű����Դϴ�. 
/// </summary>
public class CooldownTimePresenter : MonoBehaviour
{
    // ��Ÿ���� ��Ÿ���� �ؽ�Ʈ�Դϴ�. 
    [SerializeField]
    private Text cooldownTimeNumText;

    // ��Ÿ�� ���� ��Ȳ�� �����ֱ� ���� FIll�� ����մϴ�.
    [SerializeField]
    private Image fillImg;

    // ��Ÿ�� �������Դϴ�.
    private CooldownTimeModel model;

    private void Awake()
    {
        model = new CooldownTimeModel();
    }

    private void Start()
    {
        SubscribeCooldownTimeNumText();
        SubscribeFillImage();
    }

    /// <summary>
    /// ���� ��Ÿ�� ��Ȳ�� �ؽ�Ʈ�� �����ݴϴ�.
    /// </summary>
    private void SubscribeCooldownTimeNumText()
    {
        if (cooldownTimeNumText == null) return;

        // ���� ��Ÿ���� 0�� ��� ������ ����մϴ�.
        model.ObserveEveryValueChanged(model => model.CurCooldownTIme)
            .Where(curCool => curCool <= 0)
            .Subscribe(curCool => cooldownTimeNumText.text = "");

        // ���� ��Ÿ���� 1�� �̻� ���� ��� �� ������ ����մϴ�.
        model
            .ObserveEveryValueChanged(model => model.CurCooldownTIme)
            .Where(curCool => 0 < curCool && model.CooldownTIme - curCool >= 1)
            .Select(curcool => model.CooldownTIme - curcool)
            .Subscribe(curCool => cooldownTimeNumText.text = Mathf.Floor(curCool).ToString());

        // ���� ��Ÿ���� 1�� �̸����� ���� ��� �Ҽ��� ù° �ڸ��� ����մϴ�.
        model
            .ObserveEveryValueChanged(model => model.CurCooldownTIme)
            .Where(curCool => 0 < curCool && model.CooldownTIme - curCool < 1)
            .Select(curcool => model.CooldownTIme - curcool)
            .Subscribe(curCool => cooldownTimeNumText.text = (Mathf.Floor((curCool) * 10) * 0.1f).ToString());
    }

    /// <summary>
    /// ���� ��Ÿ�� ��Ȳ�� Fill �̹����� �����ݴϴ�.
    /// </summary>
    private void SubscribeFillImage()
    {
        if (fillImg == null) return;

        // ���� ��Ÿ���� 0�� ��� �̹����� ä���� �ʽ��ϴ�.
        model
           .ObserveEveryValueChanged(model => 1 - model.CurCooldownTIme / model.CooldownTIme)
           .Where(_ => model.CurCooldownTIme <= 0)
           .Subscribe(fillVal => fillImg.fillAmount = 0);

        // ���� ��Ÿ���� 0�� �ʰ��� ��� �̹����� ä��ϴ�.
        model
            .ObserveEveryValueChanged(model => 1 - model.CurCooldownTIme / model.CooldownTIme)
            .Where(_ => model.CurCooldownTIme > 0)
            .Subscribe(fillVal => fillImg.fillAmount = fillVal);
    }
}
