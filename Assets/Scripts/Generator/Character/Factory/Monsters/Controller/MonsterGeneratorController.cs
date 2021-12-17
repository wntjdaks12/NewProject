using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GeneratorInfo
{
    // ������ �ð��Դϴ�.
    public float respawnTime;

    // ������ �������Դϴ�.
    public Vector3 position;

    // ������ �������Դϴ�.
    public float size;
}

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

    // ������ �����Դϴ�.
    public GeneratorInfo generatorInfo;

    // ���� ����� �پ��ϰ� ���� �������Դϴ�.
    private GenerateBehaviour generateBehaviour;

    private void Awake()
    {
        keepPoolCount = pool.poolCount;
        curPoolCount = 0;
        resurveCount = 0;

        generateBehaviour = new SquareGenerate();
    }

    private void Start()
    {
        // ���� ��ġ�� ��� ����� Ȱ��ȭ ��ŵ�ϴ�. ------------------------------------------
        for (int i = 0; i < pool.poolCount; i++)
        {
            var obj = pool.DeQueue();
            obj.transform.position = generateBehaviour.getGenerate(generatorInfo.position, generatorInfo.size);
        }
        // -----------------------------------------------------------------------------------

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
        yield return new WaitForSeconds(generatorInfo.respawnTime);

        // Ǯ���� Ȱ��ȭ��ŵ�ϴ�.
        var obj = pool.DeQueue();
        obj.transform.position = generateBehaviour.getGenerate(generatorInfo.position, generatorInfo.size);

        // ���� ���� ���� ����
        resurveCount--;
    }

    public GenerateBehaviour GenerateBehaviour { set { generateBehaviour = value; } }
}
