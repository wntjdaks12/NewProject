using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾��� ĳ���͸� �����ϴ� ��Ʈ�ѷ��Դϴ�.
/// </summary>
public class CharacterController : PlayerController
{
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
            target.Idle();
    }
}
