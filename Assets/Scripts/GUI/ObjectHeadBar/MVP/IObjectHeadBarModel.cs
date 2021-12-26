using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 오브젝트 상단에 데이터를 보여주는 부분입니다.
/// </summary>
public interface IObjectHeadBarModel
{
    public int getLv();
    public int getHp();
    public int getMaaxHp();
}
