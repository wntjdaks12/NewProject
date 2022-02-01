using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 모든 캐릭터의 최상위입니다.
/// </summary>
public class Character : MonoBehaviour, IEquipWeapon
{
    public UnityEvent DieEvent;

    /// <summary>
    /// id값입니다.
    /// </summary>
    protected string id;

    // 현재 상태를 나타냅니다.
    private CharacterState state;

    // 현재 무기를 나타냅니다.
    private Weapon weapon;

    // 물리 제어를 위해 가져옵니다.
    private Rigidbody rigid;

    protected void Awake() => rigid = GetComponent<Rigidbody>();

    private void OnEnable() => state = CharacterIdleState.Instance;

    /// <summary>
    /// 플레이어의 공격 여부를 판단합니다.
    /// </summary>
    /// <returns>공격 여부를 리턴합니다.</returns>
    public bool CheckAttack()
    {
        // 무기가 없거나, 공격 범위가 없거나, 범위 내 콜라이더가 없을 경우 공격을 하지 않습니다.
        if ((!weapon || !weapon.AttackRange) || !weapon.AttackRange.CheckColliders())
            return false;

        return true;
    }

    /// <summary>   
    /// 플레이어를 공격하게 합니다.
    /// </summary>
    public void Attack(bool isAttacking)
    {
        if (!isAttacking)
            return;

        // 공격 상태로 변경합니다.
        state.Attack(this);

        // 공격합니다.
        weapon.Attack();
    }

    /// <summary>
    /// 플레이어를 가만히 있게 합니다.
    /// </summary>
    public void Idle() => state.Idle(this);

    /// <summary>
    /// 플레이어를 이동시킵니다.
    /// </summary>
    /// <param name="pos">이동 </param>
    /// <param name="spd">플레이어 속도</param>
    public void Move(Vector3 rotation, float speed)
    {
        // 이동 상태로 변경합니다.
        state.Move(this);

        // 퍼사드 패턴
        Direction(rotation);
        Move(speed);
    }

    /// <summary>
    /// 직선 이동을 합니다.
    /// </summary>
    /// <param name="speed">속도</param>
    public void Move(float speed)
    {
        if (!rigid)
            return;

        var vec3 = transform.forward * speed * Time.deltaTime;
        vec3.y = rigid.velocity.y;
        rigid.velocity = vec3;
    }

    // 이동 방향을 정해줍니다.
    private void Direction(Vector3 dir) => transform.rotation = Quaternion.LookRotation(dir);

    /// <summary>
    /// 사망합니다.
    /// </summary>
    public void Die() => state.Die(this);

    public void Equip(Weapon weapon) => this.weapon = weapon;

    /// <summary>
    /// id값입니다.
    /// </summary>
    public string Id { get { return id; } }

    /// <summary>
    /// 현재 무기입니다.
    /// </summary>
    public Weapon Weapon { get { return weapon; } set { weapon = value; } }

    /// <summary>
    /// 현재 상태입니다.
    /// </summary>
    public CharacterState State { set { state = value; } }
}
