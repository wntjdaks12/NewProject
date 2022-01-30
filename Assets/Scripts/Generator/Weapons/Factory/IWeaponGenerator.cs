using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 무기 생성자입니다.
/// </summary>
public interface IWeaponGenerator
{
    /// <summary>
    /// 생성합니다.
    /// </summary>
    public abstract void Generate(Vector3 pos, Transform parent);
}
