using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ü�� �ｺ �κ��� ĸ��ȭ�� �������̽��Դϴ�.
/// </summary>
public interface IDamageable
{
     /// <summary>
     /// �������� �Խ��ϴ�.
     /// </summary>
     /// <param name="owner">���ظ� �� ���</param>
     /// <param name="damage">������ ��</param>
    public void Damage(GameObject other, int damage);
}
