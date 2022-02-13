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

    public void AddJem(int amount) => data.jewel += amount;

    public int Gold { get => data ? data.gold : 0; }
    public int Jem { get => data ? data.jewel : 0; }
}
