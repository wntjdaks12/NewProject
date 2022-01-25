using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DragPnl Data")]
public class DragPnlData : ScriptableObject
{
    public Vector2 dragPosition;

    public float speed;
}
