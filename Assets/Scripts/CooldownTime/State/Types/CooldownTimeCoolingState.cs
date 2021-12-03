using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� �����Դϴ�.
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
    }

    /// <summary>
    /// �ڽ� �ν��Ͻ��� �����մϴ�.
    /// </summary>
    public static CooldownTimeCoolingState Instance { get { return instance; } }
}
