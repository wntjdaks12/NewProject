using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ĳ������ �������Դϴ�.
/// </summary>
public class CharacterGenerator : MonoBehaviour
{
    // ĳ������ �����Դϴ�.
    [SerializeField]
    private CharacterGeneratorFactory.Types type;

    // �ش� ĳ���͸� �����մϴ�.
    private void Start() => Create();

    // �ش� ĳ���͸� �����մϴ�.
    private void Create() => new CharacterGeneratorFactory().Create(type)?.Generate();
}
