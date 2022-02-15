using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class IAPJemSlotPresenter : MonoBehaviour
{
    // 보석 데이터입니다.
    [SerializeField]
    private MoneySlotModel model;

    // 보석의 양입니다.
    [SerializeField]
    private int amount;

    public void AddJem() => model.AddJem(amount);
}
