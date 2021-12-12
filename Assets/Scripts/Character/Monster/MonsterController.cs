using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 몬스터를 제어하는 컨트롤러입니다.
/// </summary>
public class MonsterController : MonoBehaviour
{
    /// <summary>
    /// 해당 몬스터 대상입니다.
    /// </summary>
    public Monster target;

    // 해당 대상의 데이터 값입니다.
    [SerializeField]
    private CharacterInfo data;

    private void Start()
    {
        // 데이터를 읽습니다.
        DataLoad();
    }

    // 데이터를 읽습니다.
    private void DataLoad()
    {
        data = MonsterDatabase.SearchData(target.Id);
    }

    // 해당 플레이어를 제어합니다.
    private void Control()
    {
    }

    private void FixedUpdate()
    {
        // 해당 대상을 제어합니다.
        Control();
    }
}
