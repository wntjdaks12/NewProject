using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��Ÿ�� ������ ���� �� �� �κ��Դϴ�.
/// </summary>
public class CooldownTimeNoneState : CooldownTimeState
{
    // �ڽ� �ν��Ͻ� �Դϴ�.
    private static CooldownTimeNoneState instance = new CooldownTimeNoneState();

    /// <summary>
    /// ���´� ������ �մϴ�.
    /// </summary>
    /// <param name="cooldownTime">��Ÿ�� �ּڰ�</param>
    public void Cooling(CooldownTime cooldownTime)
    {
        cooldownTime.State = CooldownTimeCoolingState.Instance;

        cooldownTime.IsOperating = true;
    }

    /// <summary>
    /// ���´� ���� �� �� ������ �մϴ�.
    /// </summary>
    /// <param name="cooldownTime">��Ÿ�� �ּڰ�</param>
    public void None(CooldownTime cooldownTime)
    {
    }

    /// <summary>
    /// �ڽ� �ν��Ͻ� �Դϴ�.
    /// </summary>
    public static CooldownTimeNoneState Instance { get { return instance; } }
}
