using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ĳ������ �������Դϴ�.
/// </summary>
public class CharacterGenerator : MonoBehaviour
{
    // ĳ������ �����Դϴ�.
    public CharacterGeneratorFactory.Types type;

    // ���� ��ġ�Դϴ�.
    public Vector3 genPos;

    private void Start() => Create();

    /// <summary>
    /// �ش� ĳ���͸� �����մϴ�.
    /// </summary>
    public void Create() => new CharacterGeneratorFactory().Create(type)?.Generate(genPos);
}
