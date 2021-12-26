using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 오브젝트 상단에 몬스터 데이터를 보여주는 부분입니다.
/// </summary>
public class MonsterData : MonoBehaviour
{
    private CharacterInfo data;

    /// <summary>
    /// 데이터를 읽습니다.
    /// </summary>
    /// <param name="id">해당 몬스터 ID</param>
    public void DataLoad(string id)
    {
        data = MonsterDatabase.SearchData(id);
    }

    public CharacterInfo Data { get => data; }
}
