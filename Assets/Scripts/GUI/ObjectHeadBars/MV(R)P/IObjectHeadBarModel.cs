using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 오브젝트 상단에 데이터를 보여주는 부분입니다.
/// </summary>
public interface IObjectHeadBarModel
{
    /// <summary>
    /// 오브젝트의 레벨입니다.
    /// </summary>
    /// <returns>레벨을 리턴합니다.</returns>
    public int getLv();

    /// <summary>
    /// 오브젝트의 체력입니다.
    /// </summary>
    /// <returns>체력을 리턴합니다.</returns>
    public int getHp();

    /// <summary>
    /// 오브젝트 최대 체력입니다.
    /// </summary>
    /// <returns>현재 체력을 리턴합니다.</returns>
    public int getMaaxHp();
}
