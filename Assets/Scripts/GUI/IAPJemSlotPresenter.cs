using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class IAPJemSlotPresenter : MonoBehaviour
{
    // ���� �������Դϴ�.
    [SerializeField]
    private MoneySlotModel model;

    // ������ ���Դϴ�.
    [SerializeField]
    private int amount;

    public void AddJem() => model.AddJem(amount);
}
