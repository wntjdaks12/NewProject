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
    }

    public void Die(Character character)
    {
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
    }

    public static CharacterDieState Instance { get { return instance; } }
}
