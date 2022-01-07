using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 몬스터(UnName1)의 생성자입니다.
/// </summary>
public class UnName1Generator : MonsterGenerator
{
    /// <summary>
    /// 생성합니다.
    /// </summary>
    public override void Generate() => MonoBehaviour.Instantiate(Resources.Load("Prefabs/Characters/Monsters/UnName1(ObjectPooling)"));
}
