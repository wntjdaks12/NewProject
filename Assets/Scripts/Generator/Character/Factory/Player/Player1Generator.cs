using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾��� �������Դϴ�.
/// </summary>
public class Player1Generator : PlayerGenerator
{
    /// <summary>
    /// �����մϴ�.
    /// </summary>
    public override void Generate()
    {
        MonoBehaviour.Instantiate(Resources.Load("Prefabs/Characters/Player/Player1"));
    }
}
