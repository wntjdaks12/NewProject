using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 몬스터 생성을 제어하는 컨트롤러입니다.
/// </summary>
public class MonsterGeneratorController : MonoBehaviour
{
    // 리스폰을 위해 오브젝트 풀링을 사용합니다.
    [SerializeField]
    private Pool pool;

    private void Start()
    {
        pool.DeQueue();
    }
}
