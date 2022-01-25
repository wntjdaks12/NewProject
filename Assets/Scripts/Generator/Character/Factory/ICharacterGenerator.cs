using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 캐릭터 생성을 위한 인터페이스입니다.
/// </summary>
public interface ICharacterGenerator
{
    /// <summary>
    /// 생성합니다.
    /// </summary>
    public void Generate(Vector3 pos);
}
