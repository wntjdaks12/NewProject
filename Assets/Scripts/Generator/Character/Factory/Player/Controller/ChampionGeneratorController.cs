using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionGeneratorController : MonoBehaviour
{
    // 리스폰을 위해 오브젝트 풀링을 사용합니다.
    [SerializeField]
    private Pool pool;

    private void Start()
    {
        if (pool == null) return;

        pool.Init();

        var obj = pool.DeQueue(); Debug.Log(obj);
        obj.transform.position = transform.position;
    }
}
