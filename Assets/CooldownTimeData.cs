using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CooldownTimeInfo
{
    public float cooldownTime;
    public float curCooldownTime;

    public CooldownTimeInfo(float cooldownTime, float curCooldownTime)
    {
        this.cooldownTime = cooldownTime;
        this.curCooldownTime = curCooldownTime;
    }
}

[CreateAssetMenu(fileName = "CooldownTime Data")]
public class CooldownTimeData : ScriptableObject
{
    [SerializeField]
    private CooldownTimeInfo cooldownTimeInfo;

    public CooldownTimeInfo CooldownTimeInfo { get => cooldownTimeInfo; set => cooldownTimeInfo = value; }
}
