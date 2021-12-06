using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ĳ���� ������ �̵��ϴ� �κ��Դϴ�.
/// </summary>
public class CharacterMoveState : CharacterState
{
    // �ڽ� �ν��Ͻ� �Դϴ�.
    private static CharacterMoveState instance = new CharacterMoveState();

    /// <summary>
    /// ���´� �������� �մϴ�.
    /// </summary>
    /// <param name="character">ĳ���� �ּڰ�</param>
    public void Attack(Character character)
    {
        // ���¸� �������� �����մϴ�.
        character.State = CharacterAttackState.Instance;
        character.stateType = Character.StateTypes.Attack;
    }

    /// <summary>
    /// ���´� ������ �ִ� ������ �մϴ�.
    /// </summary>
    /// <param name="character">ĳ���� �ּڰ�</param>
    public void Idle(Character character)
    {
        // ���¸� ������ �ִ� ������ �����մϴ�.
        character.State = CharacterIdleState.Instance;
        character.stateType = Character.StateTypes.Idle;
    }

    /// <summary>
    /// ���´� �̵����� �մϴ�.
    /// </summary>
    /// <param name="character">ĳ���� �ּڰ�</param>
    public void Move(Character character)
    {
    }

    /// <summary>
    /// �ڽ� �ν��Ͻ� �Դϴ�.
    /// </summary>
    public static CharacterMoveState Instance { get { return instance; } }
}
