using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 무기 생성자입니다.
/// </summary>
public class WeaponGenerator : MonoBehaviour
{
    // 무기 종류입니다.
    public WeaponCreateFactory.Types type;

    // 생성 위치입니다.
    public Vector3 genPos;

    // 생성될 부모입니다.
    public Transform parent;
    private void Start() => Create();

    /// <summary>
    /// 해당 캐릭터를 생성합니다.
    /// </summary>
    public void Create() => new WeaponCreateFactory().Create(type)?.Generate(genPos, parent);
}
