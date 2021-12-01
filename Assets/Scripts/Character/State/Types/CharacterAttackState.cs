using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackState : CharacterState
{
    // �ڽ� �ν��Ͻ� �Դϴ�.
    private static CharacterAttackState instance = new CharacterAttackState();

    /// <summary>
    /// ���´� �������� �մϴ�.
    /// </summary>
    /// <param name="character">ĳ���� �ּڰ�</param>
    public void Attack(Character character)
    {
    }

    /// <summary>
    /// ���´� ������ �ִ� ������ �մϴ�.
    /// </summary>
    /// <param name="character">ĳ���� �ּڰ�</param>
    public void Idle(Character character)
    {
        character.State = CharacterIdleState.Instance;
        character.stateType = Character.StateTypes.Idle;
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
    public static CharacterAttackState Instance { get { return instance; } }
}
