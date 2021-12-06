using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ĳ���� ������ ������ �ִ� �κ��Դϴ�.
/// </summary>
public class CharacterIdleState : CharacterState
{
    // �ڽ� �ν��Ͻ� �Դϴ�.
    private static CharacterIdleState instance = new CharacterIdleState();

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
    }

    /// <summary>
    /// ���´� �̵����� �մϴ�.
    /// </summary>
    /// <param name="character">ĳ���� �ּڰ�</param>
    public void Move(Character character)
    {
        // ���¸� �̵����� �����մϴ�.
        character.State = CharacterMoveState.Instance;
        character.stateType = Character.StateTypes.Move;
    }

    /// <summary>
    /// �ڽ� �ν��Ͻ� �Դϴ�.
    /// </summary>
    public static CharacterIdleState Instance { get { return instance; } }
}
