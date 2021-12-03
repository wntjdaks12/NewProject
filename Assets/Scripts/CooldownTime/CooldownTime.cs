using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��Ÿ���Դϴ�.
/// </summary>
public class CooldownTime : MonoBehaviour
{
    // ���� �����Դϴ�.
    private CooldownTimeState state;

    public void Awake()
    {
        state = CooldownTimeNoneState.Instance;
    }

    /// <summary>
    /// ��Ÿ���� �����մϴ�.
    /// </summary>
    public void StartCooldownTime()
    {
        state.Cooling(this);
    }

    /// <summary>
    /// ��Ÿ�� �ڷ�ƾ�� �����մϴ�.
    /// </summary>
    public void CoroutineCooldownTime()
    {
        StartCoroutine(CooldownTimeAsync());
    }

    // ��Ÿ�� �ڷ�ƾ�� �۵��մϴ�.
    private IEnumerator CooldownTimeAsync()
    {
        yield return new WaitForSeconds(1f);
        state.None(this);
    }

    /// <summary>
    /// ��Ÿ�� �����Դϴ�.
    /// </summary>
    public CooldownTimeState State { set { state = value; } }
}
