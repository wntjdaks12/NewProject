using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TMPro;

/// <summary>
/// 골드 슬롯의 UGUI와 데이터를 연결해 주는 매개자입니다. 
/// </summary>
public class GoldSlotPresenter : MonoBehaviour
{
    // 돈 데이터입니다.
    [SerializeField]
    private MoneySlotModel model;

    // 골드 슬롯의 데이터입니다.
    [SerializeField]
    private TextMeshProUGUI goldTmp;

    private void Start() =>
        model.ObserveEveryValueChanged(model => model.Data.gold)
            .Subscribe(gold => goldTmp.text = gold.ToString());
}
