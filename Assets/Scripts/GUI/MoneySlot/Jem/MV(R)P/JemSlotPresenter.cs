using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TMPro;

/// <summary>
/// 보석 슬롯의 UGUI와 데이터를 연결해 주는 매개자입니다. 
/// </summary>
public class JemSlotPresenter : MoneySlotPresenter
{
    private void Start()
    {
        if (model != null && moneyTmp != null)
            model.ObserveEveryValueChanged(_ => model.Jem)
                .Subscribe(jem => moneyTmp.text = jem.ToString());
    }
}
