using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� �������Դϴ�.
/// </summary>
public interface IWeaponGenerator
{
    /// <summary>
    /// �����մϴ�.
    /// </summary>
    public abstract void Generate(Vector3 pos, Transform parent);
}
