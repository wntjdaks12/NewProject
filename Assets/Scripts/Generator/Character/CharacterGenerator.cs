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

    // ���� ��ġ�Դϴ�.
    public Vector3 genPos;

    private void Start() => Create();

    /// <summary>
    /// �ش� ĳ���͸� �����մϴ�.
    /// </summary>
    private void Create() => new CharacterGeneratorFactory().Create(type)?.Generate(genPos);
}
