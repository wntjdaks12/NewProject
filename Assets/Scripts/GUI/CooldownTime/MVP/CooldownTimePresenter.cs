using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class CooldownTimePresenter : MonoBehaviour
{
    [SerializeField]
    private Text cooldownTimeNumText;

    [SerializeField]
    private Image fillImg;

    private CooldownTimeModel model;

    private void Awake()
    {
        model = new CooldownTimeModel();
    }

    private void Start()
    {
        if (cooldownTimeNumText == null) return;

        model.ObserveEveryValueChanged(model => model.CurCooldownTIme)
            .Where(curCool => curCool <= 0)
            .Subscribe(curCool => cooldownTimeNumText.text = "");

        model
            .ObserveEveryValueChanged(model => model.CurCooldownTIme)
            .Where(curCool => 0 < curCool && model.CooldownTIme - curCool >= 1)
            .Select(curcool => model.CooldownTIme - curcool)
            .Subscribe(curCool => cooldownTimeNumText.text = Mathf.Floor(curCool).ToString());

        model
            .ObserveEveryValueChanged(model => model.CurCooldownTIme)
            .Where(curCool => 0 < curCool && model.CooldownTIme - curCool < 1)
            .Select(curcool => model.CooldownTIme - curcool)
            .Subscribe(curCool => cooldownTimeNumText.text = (Mathf.Floor((curCool) * 10) * 0.1f).ToString());

        if (fillImg == null) return;

        model
           .ObserveEveryValueChanged(model => 1 - model.CurCooldownTIme / model.CooldownTIme)
           .Where(_ => model.CurCooldownTIme <= 0)
           .Subscribe(fillVal => fillImg.fillAmount = 0);

        model
            .ObserveEveryValueChanged(model => 1 - model.CurCooldownTIme / model.CooldownTIme)
            .Where(_ => model.CurCooldownTIme > 0)
            .Subscribe(fillVal => fillImg.fillAmount = fillVal);
    }
}
