using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ��� ĳ������ �ֻ����Դϴ�.
/// </summary>
public class Character : MonoBehaviour
{
    public UnityEvent DieEvent;

    /// <summary>
    /// id���Դϴ�.
    /// </summary>
    protected string id;

    // ���� ���¸� ��Ÿ���ϴ�.
    protected CharacterState state;
    public enum StateTypes { Idle, Move, Attack }
    [HideInInspector]
    public StateTypes stateType = StateTypes.Idle;

    // ���� ���⸦ ��Ÿ���ϴ�.
    private Weapon weapon;

    // ���� ��� ���� �����ɴϴ�.
    protected Rigidbody rigid;

    // Ǯ���� ������Ʈ�Դϴ�.
    private PoolableObject poolableObject;

    protected void Awake()
    {
        rigid = GetComponent<Rigidbody>();

        poolableObject = GetComponent<PoolableObject>();
    }

    private void OnEnable()
    {
        state = CharacterIdleState.Instance;
    }

    /// <summary>
    /// �÷��̾��� ���� ���θ� �Ǵ��մϴ�.
    /// </summary>
    /// <returns>���� ���θ� �����մϴ�.</returns>
    public bool CheckAttack()
    {
        // ���Ⱑ ���ų�, ���� ������ ���ų�, ���� �� �ݶ��̴��� ���� ��� ������ ���� �ʽ��ϴ�.
        if ((!weapon || !weapon.AttackRange) || !weapon.AttackRange.CheckColliders())
            return false;

        return true;
    }

    /// <summary>   
    /// �÷��̾ �����ϰ� �մϴ�.
    /// </summary>
    public void Attack(bool isAttacking)
    {
        if (!isAttacking)
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
    public void Move(Vector3 rotation, float speed)
    {
        // �̵� ���·� �����մϴ�.
        state.Move(this);

        // �ۻ�� ����
        Direction(rotation);
        Move(speed);
    }

    // �̵� ������ �����ݴϴ�.
    private void Direction(Vector3 dir)
    {
        transform.rotation = Quaternion.LookRotation(dir);
    }

    /// <summary>
    /// ���� �̵��� �մϴ�.
    /// </summary>
    /// <param name="speed">�ӵ�</param>
    public void Move(float speed)
    {
        if (!rigid)
            return;

        var vec3 = transform.forward * speed * Time.deltaTime;
        vec3.y = rigid.velocity.y;
        rigid.velocity = vec3;
    }

    /// <summary>
    /// ����մϴ�.
    /// </summary>
    public void Die()
    {
        // ������� �����մϴ�.
        state.Die(this);
    }

    /// <summary>
    /// id���Դϴ�.
    /// </summary>
    public string Id { get { return id; } }

    /// <summary>
    /// ���� �����Դϴ�.
    /// </summary>
    public Weapon Weapon { get { return weapon; } set { weapon = value; } }

    /// <summary>
    /// ���� �����Դϴ�.
    /// </summary>
    public CharacterState State { set { state = value; } }

    //
    public PoolableObject PoolableObject { get { return poolableObject; } }
}
