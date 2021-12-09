using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 모든 캐릭터의 최상위입니다.
/// </summary>
public class Character : MonoBehaviour
{
    // 현재 상태를 나타냅니다.
    protected CharacterState state;
    public enum StateTypes {Idle, Move, Attack}
    [HideInInspector]
    public StateTypes stateType;

    // 현재 무기를 나타냅니다.
    private Weapon weapon;

    // 물리 제어를 위해 가져옵니다.
    protected Rigidbody rigid;

    private void Awake()
    {
        state = CharacterIdleState.Instance;
        stateType = StateTypes.Idle;

        rigid = GetComponent<Rigidbody>() ?? GetComponent<Rigidbody>();
    }

    /// <summary>
    /// 플레이어를 공격하게 합니다.
    /// </summary>
    public void Attack()
    {
        // 무기가 없으면 공격을 안합니다.
        if (!weapon)
            return;

        // 공격 상태로 변경합니다.
        state.Attack(this);

        // 공격합니다.
        weapon.Attack();
    }

    /// <summary>
    /// 플레이어를 가만히 있게 합니다.
    /// </summary>
    public void Idle()
    {
        // 가만히 있는 상태로 변경합니다.
        state.Idle(this);
    }

    /// <summary>
    /// 플레이어를 이동시킵니다.
    /// </summary>
    /// <param name="pos">이동 </param>
    /// <param name="spd">플레이어 속도</param>
    public void Move(Vector2 rotation, float speed)
    {
        // 이동 상태로 변경합니다.
        state.Move(this);

        // 퍼사드 패턴
        Direction(rotation);
        ForwardMove(speed);
    }

    // 이동 방향을 정해줍니다.
    private void Direction(Vector2 rotation)
    {
        var vec3 = new Vector3(rotation.x, rotation.y, 0) - Vector3.forward;

        transform.rotation = Quaternion.Euler(0, -Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg + 90, 0);
    }

    // 직선 이동을 합니다.
    private void ForwardMove(float speed)
    {
        if (rigid)
            rigid.velocity = transform.forward * speed * Time.deltaTime;
    }

    /// <summary>
    /// 현재 무기입니다.
    /// </summary>
    public Weapon Weapon { get { return weapon; } set { weapon = value; } }

    /// <summary>
    /// 현재 상태입니다.
    /// </summary>
    public CharacterState State { set { state = value; } }
}
