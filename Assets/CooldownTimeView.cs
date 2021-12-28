using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownTimeView : MonoBehaviour
{
    [SerializeField]
    private Image slotImg;

    [SerializeField]
    private Image fillImg;

    private CooldownTimePresenter presenter;

    private void Awake()
    {
        presenter = new CooldownTimePresenter(this, new WeaponCooldownTimeModel());
    }

    public void StartCool()
    {
        slotImg.gameObject.SetActive(true);

        StartCoroutine(CoolAsync());
    }

    private IEnumerator CoolAsync()
    {
        yield return new WaitForSeconds(presenter.cooldownTime);

        slotImg.gameObject.SetActive(false);
    }
}
