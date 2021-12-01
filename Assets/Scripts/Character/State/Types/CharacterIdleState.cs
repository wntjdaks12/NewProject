using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 캐릭터의 스테이트 패턴 중 가만히 있는 부분입니다.
/// </summary>
public class CharacterIdleState : CharacterState
{
    // 자신 인스턴스 입니다.
    private static CharacterIdleState instance = new CharacterIdleState();

    /// <summary>
    /// 상태는 공격으로 합니다.
    /// </summary>
    /// <param name="character">캐릭터 주솟값</param>
    public void Attack(Character character)
    {
        character.State = CharacterAttackState.Instance;
        character.stateType = Character.StateTypes.Attack;
    }

    /// <summary>
    /// 상태는 가만히 있는 것으로 합니다.
    /// </summary>
    /// <param name="character">캐릭터 주솟값</param>
    public void Idle(Character character)
    {
    }

    /// <summary>
    /// 상태는 이동으로 합니다.
    /// </summary>
    /// <param name="character">캐릭터 주솟값</param>
    public void Move(Character character)
    {
        character.State = CharacterMoveState.Instance;
        character.stateType = Character.StateTypes.Move;
    }

    /// <summary>
    /// 자신 인스턴스를 리턴합니다.
    /// </summary>
    public static CharacterIdleState Instance { get { return instance; } }
}
