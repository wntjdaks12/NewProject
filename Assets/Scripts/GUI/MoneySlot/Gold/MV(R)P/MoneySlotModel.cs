using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 돈 데이터 부분입니다.
/// </summary>
[System.Serializable]
public class MoneySlotModel
{
    // 돈 데이터입니다.
    [SerializeField]
    private MoneyData data;

    public MoneyData Data { get => data; }
}
