using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ĳ������ ������Ʈ ���� �� ������ �ִ� �κ��Դϴ�.
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
        character.State = CharacterMoveState.Instance;
        character.stateType = Character.StateTypes.Move;
    }

    /// <summary>
    /// �ڽ� �ν��Ͻ��� �����մϴ�.
    /// </summary>
    public static CharacterIdleState Instance { get { return instance; } }
}
