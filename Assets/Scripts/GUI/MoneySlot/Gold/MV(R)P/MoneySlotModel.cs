using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �� ������ �κ��Դϴ�.
/// </summary>
[System.Serializable]
public class MoneySlotModel
{
    // �� �������Դϴ�.
    [SerializeField]
    private MoneyData data;

    public void AddJem(int amount) => data.jewel += amount;

    public int Gold { get => data ? data.gold : 0; }
    public int Jem { get => data ? data.jewel : 0; }
}
