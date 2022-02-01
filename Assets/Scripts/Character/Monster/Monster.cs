using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 몬스터입니다.
/// </summary>
public class Monster : Character
{
    // 풀링할 오브젝트입니다.
    [SerializeField]
    private PoolableObject poolableObject;
}
