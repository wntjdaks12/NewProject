using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����(UnName1)�� �������Դϴ�.
/// </summary>
public class UnName1Generator : MonsterGenerator
{
    /// <summary>
    /// �����մϴ�.
    /// </summary>
    public override void Generate() => MonoBehaviour.Instantiate(Resources.Load("Prefabs/Characters/Monsters/UnName1(ObjectPooling)"));
}
