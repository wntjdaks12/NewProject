using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 돈 전리품입니다.
/// </summary>
public class MoneyLoot : Loot
{
    private new void Awake()
    {
        base.Awake();

        dropBehaviour = new DropMoney();
    }
}
