using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using UniRx.Triggers;
using TMPro;

public class ObjectHeadBarPresenter : MonoBehaviour
{
    // ����, ü���� ��Ÿ���� ���� �ؽ�Ʈ�Դϴ�.
    [SerializeField]
    private TextMeshProUGUI lvText, hpText;

    // ü���� �� �̹����� ���� �� �̹����Դϴ�.
    [SerializeField]
    private Image hpImg, lerpHpImg;

    // �پ��� �����͸� �ޱ� ���� ĸ��ȭ��ŵ�ϴ�.
    private IObjectHeadBarModel model;

    private void Start()
    {
        // ���� ü���� ���� ��� �ؽ�Ʈ�� Fill �̹����� �����ϴ� ��Ʈ���Դϴ�. ----------------------------
        model
            .ObserveEveryValueChanged(_ => model.getHp())
            .Subscribe(curHp => 
            {
                if (hpText != null) hpText.text = curHp + " / " + model.getMaaxHp();

                if (hpImg != null)  hpImg.fillAmount = (float)curHp / model.getMaaxHp();
            });
        // ------------------------------------------------------------------------------------------------

        // ���� �� �̹��� ������ ���� ������Ʈ ��Ʈ���Դϴ�.
        this.UpdateAsObservable()
            .Subscribe(_ => { if (hpImg != null && lerpHpImg != null) lerpHpImg.fillAmount = Mathf.Lerp(lerpHpImg.fillAmount, hpImg.fillAmount, Time.deltaTime * 5f); });
    }

    /// <summary>
    /// ������ �κ��Դϴ�.
    /// </summary>
    public IObjectHeadBarModel Model { set => model = value; }
}
