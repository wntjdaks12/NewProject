using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDieState : CharacterState
{
    // 자신 인스턴스 입니다.
    private static CharacterDieState instance = new CharacterDieState();

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

    public void Die(Character character)
    {
        // 풀링 개체이므로 비활성화 시킵니다.
        character.PoolableObject?.EnQueue();
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
        // 상태를 사망으로 변경합니다.
        character.State = CharacterMoveState.Instance;
        character.stateType = Character.StateTypes.Move;
    }

    public static CharacterDieState Instance { get { return instance; } }
}
