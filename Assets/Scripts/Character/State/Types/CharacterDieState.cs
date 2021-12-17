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
        // ���� ���� ������ ���� �ݶ��̴����� �����ɴϴ�. ----------------------------
        var colls = character.Weapon.AttackRange.GetColliders();

        // ����� ���� �ٶ󺾴ϴ�. -------------------------------
        var targetPos = colls[0].transform.position;

        var vec3 = targetPos - character.transform.position; vec3.y = 0;
        character.transform.rotation = Quaternion.LookRotation(vec3);
        // ---------------------------------------------------
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
