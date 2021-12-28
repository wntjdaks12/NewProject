using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��Ÿ�� ������ ������ �κ��Դϴ�.
/// </summary>
public class CooldownTimeCoolingState : CooldownTimeState
{
    // �ڽ� �ν��Ͻ� �Դϴ�.
    private static CooldownTimeCoolingState instance = new CooldownTimeCoolingState();

    /// <summary>
    /// ���´� ������ �մϴ�.
    /// </summary>
    /// <param name="cooldownTime">��Ÿ�� �ּڰ�</param>
    public void Cooling(CooldownTime cooldownTime)
    {
    }

    /// <summary>
    /// ���´� ���� �� �� ������ �մϴ�.
    /// </summary>
    /// <param name="cooldownTime">��Ÿ�� �ּڰ�</param>
    public void None(CooldownTime cooldownTime)
    {
        cooldownTime.State = CooldownTimeNoneState.Instance;

        cooldownTime.IsOperating = false;
    }

    /// <summary>
    /// �ڽ� �ν��Ͻ� �Դϴ�.
    /// </summary>
    public static CooldownTimeCoolingState Instance { get { return instance; } }
}
