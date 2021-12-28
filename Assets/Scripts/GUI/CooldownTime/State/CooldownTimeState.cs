using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 쿨타임 상태를 캡슐화한 인터페이스입니다.
/// </summary>
public interface CooldownTimeState
{
    /// <summary>
    /// 상태는 적용 안 된 것으로 합니다.
    /// </summary>
    /// <param name="cooldownTime">쿨타임 주솟값</param>
    public void None(CooldownTime cooldownTime);
    /// <summary>
    /// 상태는 쿨링으로 합니다.
    /// </summary>
    /// <param name="cooldownTime">쿨타임 주솟값</param>
    public void Cooling(CooldownTime cooldownTime);
}
