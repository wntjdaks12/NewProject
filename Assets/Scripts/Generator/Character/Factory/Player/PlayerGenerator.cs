using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾��� �������Դϴ�.
/// </summary>
public class PlayerGenerator : ICharacterGenerator
{
    /// <summary>
    /// �����մϴ�.
    /// </summary>
    public void Generate()
    {
        MonoBehaviour.Instantiate(Resources.Load("Prefabs/Characters/Player/Player"));
    }
}
