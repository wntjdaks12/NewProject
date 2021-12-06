using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어의 캐릭터를 제어하는 컨트롤러입니다.
/// </summary>
public class CharacterController : PlayerController
{
    // 조이스틱 데이터 값입니다.
    [SerializeField]
    private JoystickData jStickData;

    private void FixedUpdate()
    {
        Control();
    }

    // 해당 플레이어를 제어합니다.
    private void Control()
    {
        if (!target || !jStickData)
            return;

        // 조이스틱 클릭 후 드래그 시 해당 플레이어는 움직입니다.
        if (jStickData.IsTouching && jStickData.PointerPosition != Vector2.zero)
            target.Move(jStickData.PointerPosition, 100);
        else
        {
            if (target.Weapon)
                if (target.Weapon.AttackRange)
                {
                    // 공격이 활성화 시 대상은 공격합니다.
                    if (target.Weapon.AttackRange.OverlapBehaviour.Colliders.Count != 0)
                        target.Attack();
                    //모든 조건이 충족하지 않을 경우 대상은 가만히 있습니다.
                    else
                        target.Idle();
                }else
                    target.Idle();
            else
                target.Idle();
        }
    }
}
