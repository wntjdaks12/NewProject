using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ĳ���� ������ �����ϴ� �κ��Դϴ�.
/// </summary>
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
        // ���� ���� ������ ���� �ݶ��̴����� �����ɴϴ�. ----------------------------
        var colls = character.Weapon.AttackRange.GetColliders();

        // ����� ���� �ٶ󺾴ϴ�. -------------------------------
        var targetPos = colls[0].transform.position;

        var vec3 = targetPos - character.transform.position;
        character.transform.rotation = Quaternion.LookRotation(vec3);
        // ---------------------------------------------------
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
        // ���¸� �̵����� �����մϴ�.
        character.State = CharacterMoveState.Instance;
        character.stateType = Character.StateTypes.Move;
    }

    /// <summary>
    /// �ڽ� �ν��Ͻ� �Դϴ�.
    /// </summary>
    public static CharacterAttackState Instance { get { return instance; } }
}
