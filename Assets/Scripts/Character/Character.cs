using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��� ĳ������ �ֻ����Դϴ�.
/// </summary>
public class Character : MonoBehaviour
{
    // ���� ���¸� ��Ÿ���ϴ�.
    protected CharacterState state;
    public enum StateTypes {Idle, Move, Attack}
    [HideInInspector]
    public StateTypes stateType;

    // ���� ���⸦ ��Ÿ���ϴ�.
    private Weapon weapon;

    // ���� ��� ���� �����ɴϴ�.
    protected Rigidbody rigid;

    private void Awake()
    {
        state = CharacterIdleState.Instance;
        stateType = StateTypes.Idle;

        rigid = GetComponent<Rigidbody>() ?? GetComponent<Rigidbody>();
    }

    /// <summary>
    /// �÷��̾ �����ϰ� �մϴ�.
    /// </summary>
    public void Attack()
    {
        // ���Ⱑ ������ ������ ���մϴ�.
        if (!weapon)
            return;

        // ���� ���·� �����մϴ�.
        state.Attack(this);

        // �����մϴ�.
        weapon.Attack();
    }

    /// <summary>
    /// �÷��̾ ������ �ְ� �մϴ�.
    /// </summary>
    public void Idle()
    {
        // ������ �ִ� ���·� �����մϴ�.
        state.Idle(this);
    }

    /// <summary>
    /// �÷��̾ �̵���ŵ�ϴ�.
    /// </summary>
    /// <param name="pos">�̵� </param>
    /// <param name="spd">�÷��̾� �ӵ�</param>
    public void Move(Vector2 rotation, float speed)
    {
        // �̵� ���·� �����մϴ�.
        state.Move(this);

        // �ۻ�� ����
        Direction(rotation);
        ForwardMove(speed);
    }

    // �̵� ������ �����ݴϴ�.
    private void Direction(Vector2 rotation)
    {
        var vec3 = new Vector3(rotation.x, rotation.y, 0) - Vector3.forward;

        transform.rotation = Quaternion.Euler(0, -Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg + 90, 0);
    }

    // ���� �̵��� �մϴ�.
    private void ForwardMove(float speed)
    {
        if (rigid)
            rigid.velocity = transform.forward * speed * Time.deltaTime;
    }

    /// <summary>
    /// ���� �����Դϴ�.
    /// </summary>
    public Weapon Weapon { get { return weapon; } set { weapon = value; } }

    /// <summary>
    /// ���� �����Դϴ�.
    /// </summary>
    public CharacterState State { set { state = value; } }
}
