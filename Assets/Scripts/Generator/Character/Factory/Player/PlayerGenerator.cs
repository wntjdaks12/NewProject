using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어의 생성자입니다.
/// </summary>
public abstract class PlayerGenerator : ICharacterGenerator
{
    /// <summary>
    /// 생성합니다.
    /// </summary>
    public abstract void Generate(Vector3 pos);
}
