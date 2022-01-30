using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어의 생성자입니다.
/// </summary>
public class GunslingerChampGenerator : PlayerGenerator
{
    /// <summary>
    /// 생성합니다.
    /// </summary>
    public override void Generate(Vector3 pos)
    {
        var obj = MonoBehaviour.Instantiate(Resources.Load("Prefabs/Characters/Champions/Gunslinger")) as GameObject;

        obj.transform.position = pos;
    }
}
