using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 모든 무기는 Weapon을 상속받습니다.
/// </summary>
public abstract class Weapon : MonoBehaviour
{

    // 공격 여부입니다.
    private bool isAttacking = false;

    /// <summary>
    /// 공격합니다.
    /// </summary>
    public abstract void Attack();

    protected void OnEnable()
    {
        OverlapMonsterCollider.collisionEnterEvent += ActivateAttack;
        OverlapMonsterCollider.collisionExitEvent += DeactivateAttack;
    }

    // 공격을 활성화시킵니다.
    private void ActivateAttack()
    {
        isAttacking = true;
    }

    // 공격을 비활성화시킵니다.
    private void DeactivateAttack()
    {
        isAttacking = false;
    }

    private void OnDisable()
    {
        OverlapMonsterCollider.collisionEnterEvent -= ActivateAttack;
        OverlapMonsterCollider.collisionExitEvent -= DeactivateAttack;
    }

    public bool IsAttacking { get { return isAttacking; } }
}
