using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ü�� �ｺ �κ��� ĸ��ȭ�� �������̽��Դϴ�.
/// </summary>
public interface IHealth
{
    /// <summary>
    /// �������� �Խ��ϴ�.
    /// </summary>
    /// <param name="damage">������ ��</param>
    public void Damage(int damage);
}
