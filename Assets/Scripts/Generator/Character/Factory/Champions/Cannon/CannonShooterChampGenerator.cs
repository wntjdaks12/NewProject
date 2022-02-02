using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooterChampGenerator : ChampionGenerator
{
    /// <summary>
    /// �����մϴ�.
    /// </summary>
    public override void Generate(Vector3 pos)
    {
        var obj = MonoBehaviour.Instantiate(Resources.Load("Prefabs/Characters/Champions/CannonShooter")) as GameObject;

        obj.transform.position = pos;
    }
}
