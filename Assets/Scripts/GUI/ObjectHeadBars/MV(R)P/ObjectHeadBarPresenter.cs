using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using UniRx.Triggers;
using TMPro;

public class ObjectHeadBarPresenter : MonoBehaviour
{
    // 레벨, 체력을 나타내기 위한 텍스트입니다.
    [SerializeField]
    private TextMeshProUGUI lvText, hpText;

    // 체력의 필 이미지와 러프 필 이미지입니다.
    [SerializeField]
    private Image hpImg, lerpHpImg;

    // 다양한 데이터를 받기 위해 캡슐화시킵니다.
    private IObjectHeadBarModel model;

    private void Start()
    {
        // 현재 체력이 변할 경우 텍스트와 Fill 이미지를 갱신하는 스트림입니다. ----------------------------
        model
            .ObserveEveryValueChanged(_ => model.getHp())
            .Subscribe(curHp => 
            {
                if (hpText != null) hpText.text = curHp + " / " + model.getMaaxHp();

                if (hpImg != null)  hpImg.fillAmount = (float)curHp / model.getMaaxHp();
            });
        // ------------------------------------------------------------------------------------------------

        // 러프 필 이미지 변경을 위한 업데이트 스트림입니다.
        this.UpdateAsObservable()
            .Subscribe(_ => { if (hpImg != null && lerpHpImg != null) lerpHpImg.fillAmount = Mathf.Lerp(lerpHpImg.fillAmount, hpImg.fillAmount, Time.deltaTime * 5f); });
    }

    /// <summary>
    /// 데이터 부분입니다.
    /// </summary>
    public IObjectHeadBarModel Model { set => model = value; }
}
