using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 캐릭터의 스테이트 패턴 중 이동하는 부분입니다.
/// </summary>
public class CharacterMoveState : CharacterState
{
    // 자신 인스턴스 입니다.
    private static CharacterMoveState instance = new CharacterMoveState();

    /// <summary>
    /// 상태는 가만히 있는 것으로 합니다.
    /// </summary>
    /// <param name="character">캐릭터 주솟값</param>
    public void Idle(Character character)
    {
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
    /// 자신 인스턴스를 리턴합니다.
    /// </summary>
    public static CharacterMoveState Instance { get { return instance; } }
}
