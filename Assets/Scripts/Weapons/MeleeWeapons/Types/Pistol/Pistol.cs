using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���Ÿ� ���� �� �ϳ��� �����Դϴ�.
/// </summary>
public class Pistol : RangedWeapon
{
    public new void Awake()
    {
        base.Awake();
    }

    /// <summary>
    /// �����մϴ�.
    /// </summary>
    public override void Attack()
    {
        if (pool && cooldownTime.stateType == CooldownTime.StateType.None)
            pool.DeQueue();

        // ��Ÿ���� �����մϴ�.
        cooldownTime?.StartCooldownTime();
    }
}
