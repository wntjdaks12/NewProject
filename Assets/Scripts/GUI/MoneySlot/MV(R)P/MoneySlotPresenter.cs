using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// 돈 슬롯의 UGUI와 데이터를 연결해 주는 매개자입니다. 
/// </summary>
public class MoneySlotPresenter : MonoBehaviour
{
    // 돈 데이터입니다.
    [SerializeField]
    protected MoneySlotModel model;

    // 돈 슬롯의 데이터입니다.
    [SerializeField]
    protected TextMeshProUGUI moneyTmp;
}
