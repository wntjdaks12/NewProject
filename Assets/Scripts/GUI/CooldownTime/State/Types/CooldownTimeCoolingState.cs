using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 쿨타임 상태중 쿨링중인 부분입니다.
/// </summary>
public class CooldownTimeCoolingState : CooldownTimeState
{
    // 자신 인스턴스 입니다.
    private static CooldownTimeCoolingState instance = new CooldownTimeCoolingState();

    /// <summary>
    /// 상태는 쿨링으로 합니다.
    /// </summary>
    /// <param name="cooldownTime">쿨타임 주솟값</param>
    public void Cooling(CooldownTime cooldownTime)
    {
    }

    /// <summary>
    /// 상태는 적용 안 된 것으로 합니다.
    /// </summary>
    /// <param name="cooldownTime">쿨타임 주솟값</param>
    public void None(CooldownTime cooldownTime)
    {
        cooldownTime.State = CooldownTimeNoneState.Instance;

        cooldownTime.IsOperating = false;
    }

    /// <summary>
    /// 자신 인스턴스 입니다.
    /// </summary>
    public static CooldownTimeCoolingState Instance { get { return instance; } }
}
