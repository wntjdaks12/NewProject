using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

/// <summary>
/// 쿨타임 슬롯의 UGUI와 데이터를 연결해 주는 매개자입니다. 
/// </summary>
public class CooldownTimePresenter : MonoBehaviour
{
    // 쿨타임을 나타내는 텍스트입니다. 
    [SerializeField]
    private Text cooldownTimeNumText;

    // 쿨타임 진행 상황을 보여주기 위해 FIll을 사용합니다.
    [SerializeField]
    private Image fillImg;

    // 쿨타임 데이터입니다.
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
    /// 현재 쿨타임 상황을 텍스트로 보여줍니다.
    /// </summary>
    private void SubscribeCooldownTimeNumText()
    {
        if (cooldownTimeNumText == null) return;

        // 현재 쿨타임이 0일 경우 공백을 기록합니다.
        model.ObserveEveryValueChanged(model => model.CurCooldownTIme)
            .Where(curCool => curCool <= 0)
            .Subscribe(curCool => cooldownTimeNumText.text = "");

        // 현재 쿨타임이 1초 이상 남을 경우 초 단위로 기록합니다.
        model
            .ObserveEveryValueChanged(model => model.CurCooldownTIme)
            .Where(curCool => 0 < curCool && model.CooldownTIme - curCool >= 1)
            .Select(curcool => model.CooldownTIme - curcool)
            .Subscribe(curCool => cooldownTimeNumText.text = Mathf.Floor(curCool).ToString());

        // 현재 쿨타임이 1초 미만으로 남을 경우 소수점 첫째 자리로 기록합니다.
        model
            .ObserveEveryValueChanged(model => model.CurCooldownTIme)
            .Where(curCool => 0 < curCool && model.CooldownTIme - curCool < 1)
            .Select(curcool => model.CooldownTIme - curcool)
            .Subscribe(curCool => cooldownTimeNumText.text = (Mathf.Floor((curCool) * 10) * 0.1f).ToString());
    }

    /// <summary>
    /// 현재 쿨타임 상황을 Fill 이미지로 보여줍니다.
    /// </summary>
    private void SubscribeFillImage()
    {
        if (fillImg == null) return;

        // 현재 쿨타임이 0일 경우 이미지를 채우지 않습니다.
        model
           .ObserveEveryValueChanged(model => 1 - model.CurCooldownTIme / model.CooldownTIme)
           .Where(_ => model.CurCooldownTIme <= 0)
           .Subscribe(fillVal => fillImg.fillAmount = 0);

        // 현재 쿨타임이 0을 초과일 경우 이미지를 채웁니다.
        model
            .ObserveEveryValueChanged(model => 1 - model.CurCooldownTIme / model.CooldownTIme)
            .Where(_ => model.CurCooldownTIme > 0)
            .Subscribe(fillVal => fillImg.fillAmount = fillVal);
    }
}
