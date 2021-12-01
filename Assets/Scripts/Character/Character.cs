using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ĳ�����Դϴ�.
/// </summary>
public class Character : MonoBehaviour
{
    // ���� ���¸� ��Ÿ���ϴ�.
    protected CharacterState state;
    public enum StateTypes {Idle, Move, Die}
    [HideInInspector]
    public StateTypes stateType;

    // ���� ��� ���� �����ɴϴ�.
    protected Rigidbody rigid;

    private void Awake()
    {
        state = CharacterIdleState.Instance;
        stateType = StateTypes.Idle;

        rigid = GetComponent<Rigidbody>() ?? GetComponent<Rigidbody>();
    }

    public CharacterState State { set { state = value; } }
}
