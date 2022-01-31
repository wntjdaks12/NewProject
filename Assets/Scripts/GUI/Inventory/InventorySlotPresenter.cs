using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using TMPro;

public class InventorySlotPresenter : MonoBehaviour
{
    // 메인 이미지입니다.
    [SerializeField]
    private Image mainImg;

    // 메인 이미지의 이름입니다. 
    [SerializeField]
    private TextMeshProUGUI nameTMP;

    // 슬롯 버튼입니다.
    [SerializeField]
    private Button btn;

    // 데이터입니다.
    [SerializeField]
    private InventorySlotModel model;

    private void Start()
    {
        if (model == null) return;

        // 해당 슬롯 위치의 이미지가 변할 경우 갱신하는 스트림입니다.
        if (mainImg != null)
            model.ObserveEveryValueChanged(_ => model.getCharacterInfo(transform.GetSiblingIndex()).image) 
                .Subscribe(image => mainImg.sprite = Resources.Load<Sprite>("Images/Champions/" + image));

        // 해당 슬롯 위치의 이름이 변할 경우 갱신하는 스트림입니다.
        if (nameTMP != null)
            model.ObserveEveryValueChanged(_ => model.getCharacterInfo(transform.GetSiblingIndex()).keyName)
                .Subscribe(text => nameTMP.text = text);

        if (btn != null)
            // 버튼 클릭 시 해당 챔피언을 생성합니다.
            btn.OnClickAsObservable()
            .Subscribe(_ => model.Create(model.getCharacterInfo(transform.GetSiblingIndex()).keyName));
    }
}
