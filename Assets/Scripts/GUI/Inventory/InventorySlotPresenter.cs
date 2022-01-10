using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using TMPro;

public class InventorySlotPresenter : MonoBehaviour
{

    // 메인 이미지입니다.
    [SerializeField]
    private Image mainImg;

    // 메인 이미지의 이름입니다. 
    [SerializeField]
    private TextMeshProUGUI nameTMP;

    // 데이터입니다.
    private IntentorySlotModel model;

    private void Awake() => model = new IntentorySlotModel();

    private void Start()
    {
        if (model == null) return;

        // 해당 슬롯 위치의 이미지가 변할 경우 갱신하는 스트림입니다.
        if (mainImg != null)
            model.ObserveEveryValueChanged(_ => model.getWeaponInfo(transform.GetSiblingIndex()).image) 
                .Subscribe(image => mainImg.sprite = Resources.Load<Sprite>("Images/Weapons/" + image));

        // 해당 슬롯 위치의 이름이 변할 경우 갱신하는 스트림입니다.
        if (nameTMP != null)
            model.ObserveEveryValueChanged(_ => model.getWeaponInfo(transform.GetSiblingIndex()).keyName)
                .Subscribe(text => nameTMP.text = text);
    }

    /// <summary>
    /// 현재 무기 데이터를 바꿉니다.
    /// </summary>
    public void Click()
    {
        if (model != null) model.WeaponInfo = model.getWeaponInfo(transform.GetSiblingIndex());
    }
}
