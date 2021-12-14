using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 몬스터에 속한 UnName1입니다.
/// </summary>
public class UnName1 : Monster
{
    private new void Awake()
    {
        base.Awake();

        id = "unName_001";
    }
}
