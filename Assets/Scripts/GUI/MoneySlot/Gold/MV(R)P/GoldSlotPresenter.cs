using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// 골드 슬롯의 UGUI와 데이터를 연결해 주는 매개자입니다. 
/// </summary>
public class GoldSlotPresenter : MoneySlotPresenter
{
    private void Start()
    {
        if (model != null && moneyTmp != null)
            model.ObserveEveryValueChanged(_ => model.Gold)
                .Subscribe(gold => moneyTmp.text = gold.ToString());
    }
}
