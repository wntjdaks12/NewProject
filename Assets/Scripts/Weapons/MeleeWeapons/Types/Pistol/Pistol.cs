using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 원거리 무기 중 하나인 권총입니다.
/// </summary>
public class Pistol : RangedWeapon
{
    public new void Awake()
    {
        base.Awake();
    }

    /// <summary>
    /// 공격합니다.
    /// </summary>
    public override void Attack()
    {
        if (pool && cooldownTime.stateType == CooldownTime.StateType.None)
            pool.DeQueue();

        // 쿨타임을 적용합니다.
        cooldownTime?.StartCooldownTime();
    }
}
