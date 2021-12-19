using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 개체의 헬스 부분을 캡슐화한 인터페이스입니다.
/// </summary>
public interface IDamageable
{
     /// <summary>
     /// 데미지를 입습니다.
     /// </summary>
     /// <param name="owner">피해를 준 대상</param>
     /// <param name="damage">데미지 값</param>
    public void Damage(GameObject other, int damage);
}
