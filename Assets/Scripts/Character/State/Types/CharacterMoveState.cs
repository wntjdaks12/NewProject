using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ĳ������ ������Ʈ ���� �� �̵��ϴ� �κ��Դϴ�.
/// </summary>
public class CharacterMoveState : CharacterState
{
    // �ڽ� �ν��Ͻ� �Դϴ�.
    private static CharacterMoveState instance = new CharacterMoveState();

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
    }

    /// <summary>
    /// �ڽ� �ν��Ͻ��� �����մϴ�.
    /// </summary>
    public static CharacterMoveState Instance { get { return instance; } }
}
