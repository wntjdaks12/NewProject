using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCooldownTimeModel : ICooldownTimeView
{
    private CooldownTime cooldownTime;

    public float getCooldownTIme()
    {
        return cooldownTime.CurCoolVal;
    }

    public CooldownTime CooldownTime { set => cooldownTime = value; }
}
