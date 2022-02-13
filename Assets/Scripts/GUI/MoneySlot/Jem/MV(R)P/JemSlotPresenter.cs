using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TMPro;

/// <summary>
/// ���� ������ UGUI�� �����͸� ������ �ִ� �Ű����Դϴ�. 
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
