using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 쿨타임입니다.
/// </summary>
public class CooldownTime : MonoBehaviour
{
    // 현재 상태입니다.
    private CooldownTimeState state;

    public void Awake()
    {
        state = CooldownTimeNoneState.Instance;
    }

    /// <summary>
    /// 쿨타임을 시작합니다.
    /// </summary>
    public void StartCooldownTime()
    {
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
        Debug.Log("CoolStart2");
        yield return new WaitForSeconds(1f);
        state.None(this);
        Debug.Log("CollEnd");
    }

    /// <summary>
    /// 쿨타임 상태입니다.
    /// </summary>
    public CooldownTimeState State { set { state = value; } }
}
