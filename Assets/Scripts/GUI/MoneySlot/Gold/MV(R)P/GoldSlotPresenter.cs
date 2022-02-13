using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// ��� ������ UGUI�� �����͸� ������ �ִ� �Ű����Դϴ�. 
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
