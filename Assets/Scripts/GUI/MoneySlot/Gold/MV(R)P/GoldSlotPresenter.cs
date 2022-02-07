using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TMPro;

/// <summary>
/// ��� ������ UGUI�� �����͸� ������ �ִ� �Ű����Դϴ�. 
/// </summary>
public class GoldSlotPresenter : MonoBehaviour
{
    // �� �������Դϴ�.
    [SerializeField]
    private MoneySlotModel model;

    // ��� ������ �������Դϴ�.
    [SerializeField]
    private TextMeshProUGUI goldTmp;

    private void Start() =>
        model.ObserveEveryValueChanged(model => model.Data.gold)
            .Subscribe(gold => goldTmp.text = gold.ToString());
}
