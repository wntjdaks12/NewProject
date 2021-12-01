using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 캐릭터입니다.
/// </summary>
public class Character : MonoBehaviour
{
    // 현재 상태를 나타냅니다.
    protected CharacterState state;
    public enum StateTypes {Idle, Move, Die}
    [HideInInspector]
    public StateTypes stateType;

    // 물리 제어를 위해 가져옵니다.
    protected Rigidbody rigid;

    private void Awake()
    {
        state = CharacterIdleState.Instance;
        stateType = StateTypes.Idle;

        rigid = GetComponent<Rigidbody>() ?? GetComponent<Rigidbody>();
    }

    public CharacterState State { set { state = value; } }
}
