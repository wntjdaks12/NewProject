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
        Control();Debug.Log(target.stateType);
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
            // ������ Ȱ��ȭ �� ����� �����մϴ�.
            if (isAttacking)
                target.Attack();
            //��� ������ �������� ���� ��� ����� ������ �ֽ��ϴ�.
            else
                target.Idle();
        }
    }
}
