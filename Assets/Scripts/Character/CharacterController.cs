using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾��� ĳ���͸� �����ϴ� ��Ʈ�ѷ��Դϴ�.
/// </summary>
public class CharacterController : PlayerController
{
    // ���̽�ƽ ������ ���Դϴ�.
    [SerializeField]
    private JoystickData jStickData;

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
        else
        {
            if (target.Weapon)
                if (target.Weapon.AttackRange)
                {
                    // ������ Ȱ��ȭ �� ����� �����մϴ�.
                    if (target.Weapon.AttackRange.OverlapBehaviour.Colliders.Count != 0)
                        target.Attack();
                    //��� ������ �������� ���� ��� ����� ������ �ֽ��ϴ�.
                    else
                        target.Idle();
                }else
                    target.Idle();
            else
                target.Idle();
        }
    }
}
