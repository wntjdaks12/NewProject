using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDieState : CharacterState
{
    // �ڽ� �ν��Ͻ� �Դϴ�.
    private static CharacterDieState instance = new CharacterDieState();

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

    public void Die(Character character)
    {
        // Ǯ�� ��ü�̹Ƿ� ��Ȱ��ȭ ��ŵ�ϴ�.
        character.PoolableObject?.EnQueue();
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
        // ���¸� ������� �����մϴ�.
        character.State = CharacterMoveState.Instance;
        character.stateType = Character.StateTypes.Move;
    }

    public static CharacterDieState Instance { get { return instance; } }
}
