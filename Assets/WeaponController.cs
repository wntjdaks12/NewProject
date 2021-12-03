using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾��� ���⸦ �����ϴ� ��Ʈ�ѷ��Դϴ�.
/// </summary>
public class WeaponController : PlayerController
{
    // ���� �����Դϴ�.
    private bool isAttacking;

    private void Awake()
    {
        OverlapMonsterCollider.collisionEnterEvent += ActivateAttack;
        OverlapMonsterCollider.collisionExitEvent += DeactivateAttack;
    }
    public void Start()
    {
        //�ӽ� ������
        var obj = Instantiate(Resources.Load("Prefabs/Weapons/Pistol"), target.transform) as GameObject;

        target.Weapon = obj.GetComponent<Weapon>();
    }

    private void Update()
    {
        if (isAttacking)
            target.Attack();
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
}
