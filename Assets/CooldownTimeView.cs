using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownTimeView : MonoBehaviour
{
    [SerializeField]
    private GameObject cooldownTimePnl;

    [SerializeField]
    private Image fillImg;

    [SerializeField]
    private Text cooldownTimeNumText;

    private CooldownTimePresenter presenter;

    private void Awake()
    {
        presenter = new CooldownTimePresenter(this, new WeaponCooldownTimeModel());
    }

    private void Update()
    {
        if (cooldownTimeNumText != null)
            ChangeCooldownTimeNumText();

        if (fillImg != null)
            ChangeFillImage();

        if (cooldownTimePnl != null)
            ChangeSlotImage();
    }

    private void ChangeSlotImage()
    {
        if (presenter.CurCooldownTime > 0f)
            cooldownTimePnl.gameObject.SetActive(true);
        else
            cooldownTimePnl.gameObject.SetActive(false);
    }

    private void ChangeFillImage()
    {
        if (presenter.CurCooldownTime > 0f)
            fillImg.fillAmount = 1 - presenter.CurCooldownTime / presenter.CooldownTime;
    }

    private void ChangeCooldownTimeNumText()
    {
        var tempText = "";

        var cool = presenter.CooldownTime - presenter.CurCooldownTime;

        if (presenter.CurCooldownTime != 0)
        {
            if (cool > 1f)
                tempText = Mathf.Floor(cool).ToString();
            else if (cool > 0f)
                tempText = (Mathf.Floor((cool) * 10) * 0.1f).ToString();
        }

        cooldownTimeNumText.text = tempText;
    }
}
