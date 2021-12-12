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
    private CharacterInfo characterInfo;

    public CharacterInfo CharacterInfo { get { return characterInfo; } set { characterInfo = value; } }
}
