using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// �� ������ UGUI�� �����͸� ������ �ִ� �Ű����Դϴ�. 
/// </summary>
public class MoneySlotPresenter : MonoBehaviour
{
    // �� �������Դϴ�.
    [SerializeField]
    protected MoneySlotModel model;

    // �� ������ �������Դϴ�.
    [SerializeField]
    protected TextMeshProUGUI moneyTmp;
}
