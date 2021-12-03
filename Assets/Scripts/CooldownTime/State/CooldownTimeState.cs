using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��Ÿ�� ���¸� ĸ��ȭ�� �������̽��Դϴ�.
/// </summary>
public interface CooldownTimeState
{
    /// <summary>
    /// ���´� ���� �� �� ������ �մϴ�.
    /// </summary>
    /// <param name="cooldownTime">��Ÿ�� �ּڰ�</param>
    public void None(CooldownTime cooldownTime);
    /// <summary>
    /// ���´� ������ �մϴ�.
    /// </summary>
    /// <param name="cooldownTime">��Ÿ�� �ּڰ�</param>
    public void Cooling(CooldownTime cooldownTime);
}
