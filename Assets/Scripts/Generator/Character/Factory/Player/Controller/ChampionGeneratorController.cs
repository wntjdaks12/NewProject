using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionGeneratorController : MonoBehaviour
{
    // �������� ���� ������Ʈ Ǯ���� ����մϴ�.
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
