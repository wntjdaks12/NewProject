using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��Ÿ���Դϴ�.
/// </summary>
public class CooldownTime : MonoBehaviour
{
    private bool isOperating;

    // ���� �����Դϴ�.
    private CooldownTimeState state;

    [SerializeField]
    // ��Ÿ�� ���Դϴ�.
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
    /// ��Ÿ���� �����մϴ�.
    /// </summary>
    /// <param name="cooldownTime">��Ÿ�� ��</param>
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
