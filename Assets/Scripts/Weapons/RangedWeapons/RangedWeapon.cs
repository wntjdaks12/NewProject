using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���Ÿ��� ���ϴ� �����Դϴ�.
/// </summary>
public abstract class RangedWeapon : Weapon
{
    // ����ü�� �ʿ�� �ϱ� ������ ������Ʈ Ǯ���� ����մϴ�.
    [SerializeField]
    protected Pool pool;
}
