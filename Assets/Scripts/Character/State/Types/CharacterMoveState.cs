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
        // ���� ���� ������ ���� �ݶ��̴����� �����ɴϴ�. ----------------------------
        var colls = character.Weapon.AttackRange.GetColliders();

        // ����� ���� �ٶ󺾴ϴ�. -------------------------------
        var targetPos = colls[0].transform.position;

        var vec3 = targetPos - character.transform.position; vec3.y = 0;
        character.transform.rotation = Quaternion.LookRotation(vec3);
        // ---------------------------------------------------
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

    /// <summary>
    /// ���´� �״� ������ �մϴ�.
    /// </summary>
    /// <param name="character">ĳ���� �ּڰ�</param>
    public void Die(Character character)
    {
        // ���¸� ������� �����մϴ�.
        character.State = CharacterDieState.Instance;

        // ����� ���õ� �̺�Ʈ�� ȣ���մϴ�.
        character.DieEvent?.Invoke();
    }

    /// <summary>
    /// �ڽ� �ν��Ͻ� �Դϴ�.
    /// </summary>
    public static CharacterMoveState Instance { get { return instance; } }
}
