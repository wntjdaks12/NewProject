using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어에 속한 UnName1입니다.
/// </summary>
public class GunslingerChampion : Player
{
    private new void Awake()
    {
        base.Awake();

        id = "champion_001";
    }
}
