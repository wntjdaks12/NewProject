using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 쿨타임 상태중 적용 안 된 부분입니다.
/// </summary>
public class CooldownTimeNoneState : CooldownTimeState
{
    // 자신 인스턴스 입니다.
    private static CooldownTimeNoneState instance = new CooldownTimeNoneState();

    /// <summary>
    /// 상태는 쿨링으로 합니다.
    /// </summary>
    /// <param name="cooldownTime">쿨타임 주솟값</param>
    public void Cooling(CooldownTime cooldownTime)
    {
        cooldownTime.State = CooldownTimeCoolingState.Instance;

        cooldownTime.IsOperating = true;
    }

    /// <summary>
    /// 상태는 적용 안 된 것으로 합니다.
    /// </summary>
    /// <param name="cooldownTime">쿨타임 주솟값</param>
    public void None(CooldownTime cooldownTime)
    {
    }

    /// <summary>
    /// 자신 인스턴스 입니다.
    /// </summary>
    public static CooldownTimeNoneState Instance { get { return instance; } }
}
