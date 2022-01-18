using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������� ������ ������ �κ��Դϴ�.
/// </summary>
public class StageSlotModel
{   
    // �������� �������Դϴ�.
    private StageData data;

    public StageSlotModel() => data = (StageData)Resources.Load("Datas/ScriptableObjects/Stage/Stage Data");

    // �������� �������Դϴ�.
    public StageData Data { get => data; }
}
