using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어 데이터입니다.
/// </summary>
[CreateAssetMenu(fileName = "Player Data")]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private WeaponData weaponData;

    public float Speed { get { return speed; } set { speed = value; } }
    public WeaponData WeaponData { get { return weaponData; } set { weaponData = value; } }
}
