using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 쿨타임입니다.
/// </summary>
public class CooldownTime : MonoBehaviour
{
    private bool isOperating;

    // 현재 상태입니다.
    private CooldownTimeState state;

    [SerializeField]
    // 쿨타임 값입니다.
    private CooldownTimeInfo cooldownTimeInfo;

    private void Awake()
    {
        cooldownTimeInfo = new CooldownTimeInfo(0, 0);

        state = CooldownTimeNoneState.Instance;
    }

    private void Update()
    {
        if (isOperating)
            CheckCool();
    }

    /// <summary>
    /// 쿨타임을 시작합니다.
    /// </summary>
    /// <param name="cooldownTime">쿨타임 값</param>
    public void StartCooldownTime(float cooldownTime)
    {
        cooldownTimeInfo.cooldownTime = cooldownTime;

        state.Cooling(this);
    }

    private void CheckCool() 
    {
        cooldownTimeInfo.curCooldownTime += Time.deltaTime;

        if (cooldownTimeInfo.curCooldownTime >= cooldownTimeInfo.cooldownTime)
        {
            cooldownTimeInfo.curCooldownTime = 0;

            state.None(this);
        }
    }

    public CooldownTimeInfo CooldownTimeInfo { get => cooldownTimeInfo;}

    public CooldownTimeState State { set { state = value; } }

    public bool IsOperating { get => isOperating; set => isOperating = value; }
}
