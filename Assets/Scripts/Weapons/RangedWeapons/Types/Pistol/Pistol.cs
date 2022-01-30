using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���Ÿ� ���� �� �ϳ��� �����Դϴ�.
/// </summary>
public class Pistol : RangedWeapon
{
    private void Awake() => id = "weapon_001";

    /// <summary>
    /// �����մϴ�.
    /// </summary>
    public override void Attack()
    {
        // ��Ÿ���� ���� �ƴ� �� ����ü�� �����մϴ�. -------------------------
        CreateProjectile(transform.root.gameObject, AttackRange.GetColliders()[0].gameObject);

        // ��Ÿ���� �����մϴ�.
        CooldownTime.StartCooldownTime();
    }
}
