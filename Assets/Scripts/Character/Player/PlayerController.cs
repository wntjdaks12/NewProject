using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어를 제어하는 컨트롤러입니다.
/// </summary>
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// 해당 플레이어입니다.
    /// </summary>
    public Player target;

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
        // 조건이 없을 경우 해당 플레이어는 가만히 있습니다.
        else
            target.Idle();
    }

    // 해당 대상을 공격시킵니다.
    private void Attack()
    {
        if(target)
            target.Attack();
    }
}
