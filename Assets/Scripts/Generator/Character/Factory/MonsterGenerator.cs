using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ �������Դϴ�.
/// </summary>
public abstract class MonsterGenerator : ICharacterGenerator
{
    /// <summary>
    /// �����մϴ�.
    /// </summary>
    public abstract void Generate();
}
