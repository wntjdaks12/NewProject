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
    }

    public void Die(Character character)
    {
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
    }

    public static CharacterDieState Instance { get { return instance; } }
}
