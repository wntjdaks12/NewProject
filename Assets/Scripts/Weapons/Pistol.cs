using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 다양한 무기중 하나인 권총입니다.
/// </summary>
public class Pistol : Weapon
{
    // 쿨타임 컴포넌트입니다.
    private CooldownTime cooldownTime;

    public void Awake()
    {
        cooldownTime = GetComponent<CooldownTime>() ?? GetComponent<CooldownTime>();
    }
    
    /// <summary>
    /// 공격합니다.
    /// </summary>
    public override void Attack()
    {
        cooldownTime?.StartCooldownTime();
    }
}
