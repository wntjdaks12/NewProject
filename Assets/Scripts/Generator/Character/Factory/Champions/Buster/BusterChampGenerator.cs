using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusterChampGenerator : PlayerGenerator
{
    /// <summary>
    /// 생성합니다.
    /// </summary>
    public override void Generate(Vector3 pos)
    {
        var obj = MonoBehaviour.Instantiate(Resources.Load("Prefabs/Characters/Champions/Buster")) as GameObject;

        obj.transform.position = pos;
    }
}
