using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어 데이터입니다.
/// </summary>
[CreateAssetMenu(fileName = "Player Data")]
public class PlayerData : ScriptableObject
{
    private float speed;

    /// <summary>
    /// 이동 속도 값입니다.
    /// </summary>
    public float Speed { get { return speed; } set { speed = value; } }
}
