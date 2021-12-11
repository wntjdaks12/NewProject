using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��Ÿ���Դϴ�.
/// </summary>
public class CooldownTime : MonoBehaviour
{
    public enum StateType {None, Cooling}
    /// <summary>
    /// ���� �����Դϴ�.
    /// </summary>
    public StateType stateType;

    // ���� �����Դϴ�.
    private CooldownTimeState state;

    // ��Ÿ�� ���Դϴ�.
    private float coolVal;

    public void Awake()
    {
        coolVal = 0;

        stateType = StateType.None;

        state = CooldownTimeNoneState.Instance;
    }

    /// <summary>
    /// ��Ÿ���� �����մϴ�.
    /// </summary>
    /// <param name="cooldownTime">��Ÿ�� ��</param>
    public void StartCooldownTime(float cooldownTime)
    {
        coolVal = cooldownTime;

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
        yield return new WaitForSeconds(coolVal);
        state.None(this);
    }

    /// <summary>
    /// ��Ÿ�� �����Դϴ�.
    /// </summary>
    public CooldownTimeState State { set { state = value; } }

    public float CoolVal { set { coolVal = value; } }
}
