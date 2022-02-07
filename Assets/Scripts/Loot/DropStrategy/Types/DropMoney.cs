using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �� ��� �����Դϴ�.
/// </summary>
public class DropMoney : DropBehaviour
{
    // �� �������Դϴ�.
    private MoneyData data;

    public DropMoney() =>
        data = (MoneyData)Resources.Load("Datas/ScriptableObjects/Money/Money Data");

    // ����մϴ�.
    public void Drop(int amount) => data.gold += amount;
}
