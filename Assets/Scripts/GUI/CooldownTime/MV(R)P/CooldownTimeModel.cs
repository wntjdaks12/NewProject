using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class CooldownTimeModel
{
    private CooldownTimeData cooldownTimeData;

    public CooldownTimeModel() => cooldownTimeData = (CooldownTimeData)Resources.Load("Datas/ScriptableObjects/CooldownTime/CooldownTime Data");

    public float CooldownTIme {get => cooldownTimeData.CooldownTimeInfo.cooldownTime; }

    public float CurCooldownTIme { get => cooldownTimeData.CooldownTimeInfo.curCooldownTime; }
}
