using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� �� �� �����Դϴ�.
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
        cooldownTime.CoroutineCooldownTime();

        cooldownTime.State = CooldownTimeCoolingState.Instance;
    }

    /// <summary>
    /// ���´� ���� �� �� ������ �մϴ�.
    /// </summary>
    /// <param name="cooldownTime">��Ÿ�� �ּڰ�</param>
    public void None(CooldownTime cooldownTime)
    {
    }

    /// <summary>
    /// �ڽ� �ν��Ͻ��� �����մϴ�.
    /// </summary>
    public static CooldownTimeNoneState Instance { get { return instance; } }
}
