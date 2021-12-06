using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 캐릭터 상태중 이동하는 부분입니다.
/// </summary>
public class CharacterMoveState : CharacterState
{
    // 자신 인스턴스 입니다.
    private static CharacterMoveState instance = new CharacterMoveState();

    /// <summary>
    /// 상태는 공격으로 합니다.
    /// </summary>
    /// <param name="character">캐릭터 주솟값</param>
    public void Attack(Character character)
    {
        // 상태를 공격으로 변경합니다.
        character.State = CharacterAttackState.Instance;
        character.stateType = Character.StateTypes.Attack;
    }

    /// <summary>
    /// 상태는 가만히 있는 것으로 합니다.
    /// </summary>
    /// <param name="character">캐릭터 주솟값</param>
    public void Idle(Character character)
    {
        // 상태를 가만히 있는 것으로 변경합니다.
        character.State = CharacterIdleState.Instance;
        character.stateType = Character.StateTypes.Idle;
    }

    /// <summary>
    /// 상태는 이동으로 합니다.
    /// </summary>
    /// <param name="character">캐릭터 주솟값</param>
    public void Move(Character character)
    {
    }

    /// <summary>
    /// 자신 인스턴스 입니다.
    /// </summary>
    public static CharacterMoveState Instance { get { return instance; } }
}
