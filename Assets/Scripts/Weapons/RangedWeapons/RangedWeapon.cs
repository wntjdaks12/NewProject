using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���Ÿ��� ���ϴ� �����Դϴ�.
/// </summary>
public abstract class RangedWeapon : Weapon
{
    // ����ü�� �ʿ�� �ϱ� ������ ������Ʈ Ǯ���� ����մϴ�.
    [SerializeField]
    protected Pool pool;

    private new void Start()
    {
        base.Start();

        if (pool != null)
            pool.Init();
    }

    /// <summary>
    /// �� üũ�մϴ�.
    /// </summary>
    /// <returns>���� ������ True ������ False�� �����մϴ�.</returns>
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
