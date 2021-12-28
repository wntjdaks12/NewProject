using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCooldownTimeModel : ICooldownTimeModel
{
    private CooldownTimeData cooldownTimeData;

    public WeaponCooldownTimeModel()
    {
        cooldownTimeData = (CooldownTimeData) Resources.Load("Datas/ScriptableObjects/CooldownTime/CooldownTime Data");
    }

    public float getCooldownTIme()
    {
        return cooldownTimeData.CooldownTimeInfo.cooldownTime;
    }

    public float getCurCooldownTIme()
    {
        return cooldownTimeData.CooldownTimeInfo.curCooldownTime;
    }
}
