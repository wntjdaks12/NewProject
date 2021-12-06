using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 원거리에 속하는 무기입니다.
/// </summary>
public abstract class RangedWeapon : Weapon
{
    // 투사체를 필요로 하기 때문에 오브젝트 풀링을 사용합니다.
    [SerializeField]
    protected Pool pool;
}
