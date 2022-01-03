using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// 쿨타임 슬롯의 데이터 부분입니다.
/// </summary>
public class CooldownTimeModel
{
    // 쿨타임 데이터입니다.
    private CooldownTimeData cooldownTimeData;

    public CooldownTimeModel() => cooldownTimeData = (CooldownTimeData)Resources.Load("Datas/ScriptableObjects/CooldownTime/CooldownTime Data");

    /// <summary>
    /// 쿨타임을 리턴합니다.
    /// </summary>
    public float CooldownTIme {get => cooldownTimeData.CooldownTimeInfo.cooldownTime; }

    /// <summary>
    /// 현재 쿨타임을 리턴합니다.
    /// </summary>
    public float CurCooldownTIme { get => cooldownTimeData.CooldownTimeInfo.curCooldownTime; }
}
