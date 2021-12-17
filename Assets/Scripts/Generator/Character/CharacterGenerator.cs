using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 캐릭터의 생성자입니다.
/// </summary>
public class CharacterGenerator : MonoBehaviour
{
    // 캐릭터의 종류입니다.
    [SerializeField]
    private CharacterGeneratorFactory.Types type;

    private void Start()
    {
        // 해당 캐릭터를 생성합니다.
        Create();
    }   

    // 해당 캐릭터를 생성합니다.
    private void Create()
    {
        new CharacterGeneratorFactory().Create(type)?.Generate();
    }
}
