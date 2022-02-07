using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 돈 데이터입니다.
/// </summary>
[CreateAssetMenu(fileName = "Money Data")]
public class MoneyData : ScriptableObject
{
    public int gold;
    public int jewel;
}
