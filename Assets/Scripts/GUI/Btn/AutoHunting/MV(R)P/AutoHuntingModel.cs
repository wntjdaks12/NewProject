using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ڵ� ��� ��ư�� ������ �κ��Դϴ�.
/// </summary>
public class AutoHuntingModel
{
    // �ڵ� ��� �������Դϴ�.
    private AutoHuntingData autoHuntingData;

    public AutoHuntingModel() => autoHuntingData = (AutoHuntingData)Resources.Load("Datas/ScriptableObjects/AutoHunting/AutoHunting Data");

    // �ڵ� ��� �������Դϴ�.
    public AutoHuntingData AutoHuntingData { get => autoHuntingData;}
}
