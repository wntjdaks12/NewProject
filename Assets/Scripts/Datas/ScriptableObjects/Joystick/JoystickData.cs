using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Joystick Data")]

public class JoystickData : ScriptableObject
{
    private Vector2 pointerPosition;
    private bool isTouching;

    /// <summary>
    /// Ŭ���� ������ ���Դϴ�.
    /// </summary>
    public Vector2 PointerPosition { get {return pointerPosition;} set { pointerPosition = value; } }
    /// <summary>
    /// Ŭ�� �����Դϴ�.
    /// </summary>
    public bool IsTouching { get { return isTouching; } set { isTouching = value; } }
}
