using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾��� �������Դϴ�.
/// </summary>
public class GunslingerChampGenerator : PlayerGenerator
{
    /// <summary>
    /// �����մϴ�.
    /// </summary>
    public override void Generate(Vector3 pos)
    {
        var obj = MonoBehaviour.Instantiate(Resources.Load("Prefabs/Characters/Champions/Gunslinger")) as GameObject;

        obj.transform.position = pos;
    }
}
