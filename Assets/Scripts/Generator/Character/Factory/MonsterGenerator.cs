using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 몬스터의 생성자입니다.
/// </summary>
public abstract class MonsterGenerator : ICharacterGenerator
{
    /// <summary>
    /// 생성합니다.
    /// </summary>
    public abstract void Generate();
}
