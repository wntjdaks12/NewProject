using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어의 생성자입니다.
/// </summary>
public class Player1Generator : PlayerGenerator
{
    /// <summary>
    /// 생성합니다.
    /// </summary>
    public override void Generate(Vector3 pos)
    {
        var obj = MonoBehaviour.Instantiate(Resources.Load("Prefabs/Characters/Player/Champion1(ObjectPooling)")) as GameObject;

        obj.transform.position = pos;
    }
}
