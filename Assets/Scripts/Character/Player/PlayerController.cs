using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾ �����ϴ� ��Ʈ�ѷ��Դϴ�.
/// </summary>
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// �ش� �÷��̾��Դϴ�.
    /// </summary>
    public Player target;

    // ���̽�ƽ ������ ���Դϴ�.
    [SerializeField]
    private JoystickData jStickData;

    private bool isAttacking;

    private void Awake()
    {
        OverlapMonsterCollider.collisionEnterEvent += ActivateAttack;
        OverlapMonsterCollider.collisionExitEvent += DeactivateAttack;
    }

    private void FixedUpdate()
    {
        Control();
    }

    // �ش� �÷��̾ �����մϴ�.
    private void Control()
    {
        if (!target || !jStickData)
            return;


        // ���̽�ƽ Ŭ�� �� �巡�� �� �ش� �÷��̾�� �����Դϴ�.
        if (jStickData.IsTouching && jStickData.PointerPosition != Vector2.zero)
            target.Move(jStickData.PointerPosition, 100);
        // ������ ���� ��� �ش� �÷��̾�� ������ �ֽ��ϴ�.
        else
        {
            if(!isAttacking)
                target.Idle();
            else
                // ���� ������ ������ �� ����� ������ �մϴ�.
                target.Attack();
        }
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
}
