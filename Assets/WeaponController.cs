using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어의 무기를 제어하는 컨트롤러입니다.
/// </summary>
public class WeaponController : PlayerController
{
    // 공격 여부입니다.
    private bool isAttacking;

    private void Awake()
    {
        OverlapMonsterCollider.collisionEnterEvent += ActivateAttack;
        OverlapMonsterCollider.collisionExitEvent += DeactivateAttack;
    }
    public void Start()
    {
        //임시 데이터
        var obj = Instantiate(Resources.Load("Prefabs/Weapons/Pistol"), target.transform) as GameObject;

        target.Weapon = obj.GetComponent<Weapon>();
    }

    private void Update()
    {
        if (isAttacking)
            target.Attack();
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
}
