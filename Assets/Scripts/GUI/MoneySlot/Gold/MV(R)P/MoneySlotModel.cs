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

    public MoneyData Data { get => data; }
}
