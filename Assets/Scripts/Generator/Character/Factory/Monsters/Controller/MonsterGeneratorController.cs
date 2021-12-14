using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ������ �����ϴ� ��Ʈ�ѷ��Դϴ�.
/// </summary>
public class MonsterGeneratorController : MonoBehaviour
{
    // �������� ���� ������Ʈ Ǯ���� ����մϴ�.
    [SerializeField]
    private Pool pool;

    // �����ؾ� �Ǵ� Ǯ�� �����Դϴ�. (���� ��ü ����)
    private int keepPoolCount;
    // ���� Ǯ�� �����Դϴ�. (����� �����ϴ� ���� ����)
    private int curPoolCount;
    // ����� Ǯ�� �����Դϴ�. (�� �����Ǵ� ���� ����)
    private int resurveCount;

    [SerializeField]
    private float respawnTime;

    private void Awake()
    {
        keepPoolCount = pool.poolCount;
        curPoolCount = 0;
        resurveCount = 0;
    }

    private void Start()
    {
        // ��� ����� Ȱ��ȭ ��ŵ�ϴ�.
        for (int i = 0; i < pool.poolCount; i++)
            pool.DeQueue();

        // ����� �����ϴ� ���� ���� ��ü������ Ǯ���� ��Ƴ� ������ �� ����� �����ϴ�.
        curPoolCount = keepPoolCount - pool.ObjectPool.Count;
    }

    private void Update()
    {
        // ����� �����ϴ� ���� ���� ��ü������ Ǯ���� ��Ƴ� ������ �� ����� �����ϴ�.
        curPoolCount = keepPoolCount - pool.ObjectPool.Count;

        // ���� ���� ��ü ���� ������ ���� ��� �������� �մϴ�. ---------
        if (resurveCount + curPoolCount < keepPoolCount)
            StartCoroutine(RespawnAsync());
        // -------------------------------------------------------------
    }

    // �ð��� �����Ͽ� �������� �մϴ�.
    private IEnumerator RespawnAsync()
    {
        // ���� ���� ���� ����
        resurveCount++;

        // �ش� �ð���ŭ �����մϴ�.
        yield return new WaitForSeconds(respawnTime);

        // Ǯ���� Ȱ��ȭ��ŵ�ϴ�.
        pool.DeQueue();

        // ���� ���� ���� ����
        resurveCount--;
    }
}
