using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����ü�� ������ �����ִ� �������Դϴ�.
/// </summary>
public abstract class ProjectileAttackBehaviour : MonoBehaviour
{
    // �ش� ����ü�Դϴ�.
    protected Projectile projectile;

    // �ش� ����ü�Դϴ�.
    public Projectile Projectile { set => projectile = value; }
}
