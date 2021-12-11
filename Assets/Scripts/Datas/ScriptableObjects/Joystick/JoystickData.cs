using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Joystick Data")]

public class JoystickData : ScriptableObject
{
    private Vector2 pointerPosition;
    private bool isTouching;

    /// <summary>
    /// 클릭한 포지션 값입니다.
    /// </summary>
    public Vector2 PointerPosition { get {return pointerPosition;} set { pointerPosition = value; } }
    /// <summary>
    /// 클릭 상태입니다.
    /// </summary>
    public bool IsTouching { get { return isTouching; } set { isTouching = value; } }
}
