using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 캐릭터 상태중 공격하는 부분입니다.
/// </summary>
public class CharacterAttackState : CharacterState
{
    // 자신 인스턴스 입니다.
    private static CharacterAttackState instance = new CharacterAttackState();

    /// <summary>
    /// 상태는 공격으로 합니다.
    /// </summary>
    /// <param name="character">캐릭터 주솟값</param>
    public void Attack(Character character)
    {
        // 무기 공격 범위에 접한 콜라이더들을 가져옵니다. ----------------------------
        var colls = character.Weapon.AttackRange.GetColliders();

        // 대상을 향해 바라봅니다. -------------------------------
        var targetPos = colls[0].transform.position;

        var vec3 = targetPos - character.transform.position; vec3.y = 0;
        character.transform.rotation = Quaternion.LookRotation(vec3);
        // ---------------------------------------------------
    }

    /// <summary>
    /// 상태는 가만히 있는 것으로 합니다.
    /// </summary>
    /// <param name="character">캐릭터 주솟값</param>
    public void Idle(Character character) { }

    /// <summary>
    /// 상태는 이동으로 합니다.
    /// </summary>
    /// <param name="character">캐릭터 주솟값</param>
    public void Move(Character character) { }

    /// <summary>
    /// 상태는 죽는 것으로 합니다.
    /// </summary>
    /// <param name="character">캐릭터 주솟값</param>
    public void Die(Character character)
    {
        // 상태를 사망으로 변경합니다.
        character.State = CharacterDieState.Instance;

        // 사망에 관련된 이벤트를 호출합니다.
        character.DieEvent?.Invoke();
    }

    /// <summary>
    /// 자신 인스턴스 입니다.
    /// </summary>
    public static CharacterAttackState Instance { get { return instance; } }
}
