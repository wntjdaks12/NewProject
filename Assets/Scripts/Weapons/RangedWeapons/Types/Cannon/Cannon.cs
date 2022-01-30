using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : RangedWeapon
{
    private void Awake() => id = "weapon_003";

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
