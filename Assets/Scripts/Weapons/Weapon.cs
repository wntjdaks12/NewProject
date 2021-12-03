using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��� ����� Weapon�� ��ӹ޽��ϴ�.
/// </summary>
public abstract class Weapon : MonoBehaviour
{

    // ���� �����Դϴ�.
    private bool isAttacking = false;

    /// <summary>
    /// �����մϴ�.
    /// </summary>
    public abstract void Attack();

    protected void OnEnable()
    {
        OverlapMonsterCollider.collisionEnterEvent += ActivateAttack;
        OverlapMonsterCollider.collisionExitEvent += DeactivateAttack;
    }

    // ������ Ȱ��ȭ��ŵ�ϴ�.
    private void ActivateAttack()
    {
        isAttacking = true;
    }

    // ������ ��Ȱ��ȭ��ŵ�ϴ�.
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
