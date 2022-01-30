using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� �������Դϴ�.
/// </summary>
public class WeaponGenerator : MonoBehaviour
{
    // ���� �����Դϴ�.
    public WeaponCreateFactory.Types type;

    // ���� ��ġ�Դϴ�.
    public Vector3 genPos;

    // ������ �θ��Դϴ�.
    public Transform parent;
    private void Start() => Create();

    /// <summary>
    /// �ش� ĳ���͸� �����մϴ�.
    /// </summary>
    public void Create() => new WeaponCreateFactory().Create(type)?.Generate(genPos, parent);
}
