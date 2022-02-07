using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 돈 드랍 행위입니다.
/// </summary>
public class DropMoney : DropBehaviour
{
    // 돈 데이터입니다.
    private MoneyData data;

    public DropMoney() =>
        data = (MoneyData)Resources.Load("Datas/ScriptableObjects/Money/Money Data");

    // 드랍합니다.
    public void Drop(int amount) => data.gold += amount;
}
