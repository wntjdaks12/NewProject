using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �� ����ǰ�Դϴ�.
/// </summary>
public class MoneyLoot : Loot
{
    private new void Awake()
    {
        base.Awake();

        dropBehaviour = new DropMoney();
    }
}
