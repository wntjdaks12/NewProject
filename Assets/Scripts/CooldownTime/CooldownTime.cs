using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 쿨타임입니다.
/// </summary>
public class CooldownTime : MonoBehaviour
{
    public enum StateType {None, Cooling}
    /// <summary>
    /// 현재 상태입니다.
    /// </summary>
    public StateType stateType;

    // 현재 상태입니다.
    private CooldownTimeState state;

    // 쿨타임 값입니다.
    private float coolVal;

    public void Awake()
    {
        coolVal = 0;

        stateType = StateType.None;

        state = CooldownTimeNoneState.Instance;
    }

    /// <summary>
    /// 쿨타임을 시작합니다.
    /// </summary>
    /// <param name="cooldownTime">쿨타임 값</param>
    public void StartCooldownTime(float cooldownTime)
    {
        coolVal = cooldownTime;

        state.Cooling(this);
    }

    /// <summary>
    /// 쿨타임 코루틴을 시작합니다.
    /// </summary>
    public void CoroutineCooldownTime()
    {
        StartCoroutine(CooldownTimeAsync());
    }

    // 쿨타임 코루틴을 작동합니다.
    private IEnumerator CooldownTimeAsync()
    {
        yield return new WaitForSeconds(coolVal);
        state.None(this);
    }

    /// <summary>
    /// 쿨타임 상태입니다.
    /// </summary>
    public CooldownTimeState State { set { state = value; } }

    public float CoolVal { set { coolVal = value; } }
}
