using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾��� �������Դϴ�.
/// </summary>
public abstract class ChampionGenerator : ICharacterGenerator
{
    /// <summary>
    /// �����մϴ�.
    /// </summary>
    public abstract void Generate(Vector3 pos);
}
