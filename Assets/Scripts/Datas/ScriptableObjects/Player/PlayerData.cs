using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾� �������Դϴ�.
/// </summary>
[CreateAssetMenu(fileName = "Player Data")]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private CharacterInfo characterInfo;

    public CharacterInfo CharacterInfo { get { return characterInfo; } set { characterInfo = value; } }
}
