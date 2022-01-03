using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// ��Ÿ�� ������ ������ �κ��Դϴ�.
/// </summary>
public class CooldownTimeModel
{
    // ��Ÿ�� �������Դϴ�.
    private CooldownTimeData cooldownTimeData;

    public CooldownTimeModel() => cooldownTimeData = (CooldownTimeData)Resources.Load("Datas/ScriptableObjects/CooldownTime/CooldownTime Data");

    /// <summary>
    /// ��Ÿ���� �����մϴ�.
    /// </summary>
    public float CooldownTIme {get => cooldownTimeData.CooldownTimeInfo.cooldownTime; }

    /// <summary>
    /// ���� ��Ÿ���� �����մϴ�.
    /// </summary>
    public float CurCooldownTIme { get => cooldownTimeData.CooldownTimeInfo.curCooldownTime; }
}
