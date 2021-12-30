using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 원거리에 속하는 무기입니다.
/// </summary>
public abstract class RangedWeapon : Weapon
{
    // 투사체를 필요로 하기 때문에 오브젝트 풀링을 사용합니다.
    [SerializeField]
    protected Pool pool;

    private new void Start()
    {
        base.Start();

        if (pool != null)
            pool.Init();
    }

    /// <summary>
    /// 널 체크합니다.
    /// </summary>
    /// <returns>널이 있으면 True 없으면 False를 리턴합니다.</returns>
    protected bool CheckEmpty()
    {
        if (weaponData == null || weaponData.weaponInfo == null)
            return true;

        if (CooldownTime == null || AttackRange == null)
            return true;

        if (pool != null)
            return false;

        return true;
    }
}
