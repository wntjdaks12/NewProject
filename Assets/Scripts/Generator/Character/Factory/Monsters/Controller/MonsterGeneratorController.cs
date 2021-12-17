using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GeneratorInfo
{
    // 리스폰 시간입니다.
    public float respawnTime;

    // 리스폰 기준점입니다.
    public Vector3 position;

    // 리스폰 사이즈입니다.
    public float size;
}

/// <summary>
/// 몬스터 생성을 제어하는 컨트롤러입니다.
/// </summary>
public class MonsterGeneratorController : MonoBehaviour
{
    // 리스폰을 위해 오브젝트 풀링을 사용합니다.
    [SerializeField]
    private Pool pool;

    // 유지해야 되는 풀링 개수입니다. (몬스터 전체 개수)
    private int keepPoolCount;
    // 현재 풀링 개수입니다. (월드상에 존재하는 몬스터 개수)
    private int curPoolCount;
    // 예약된 풀링 개수입니다. (곧 생성되는 몬스터 개수)
    private int resurveCount;

    // 생성자 정보입니다.
    public GeneratorInfo generatorInfo;

    // 생성 방법을 다양하게 해줄 행위자입니다.
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
        // 스폰 위치에 모든 대상을 활성화 시킵니다. ------------------------------------------
        for (int i = 0; i < pool.poolCount; i++)
        {
            var obj = pool.DeQueue();
            obj.transform.position = generateBehaviour.getGenerate(generatorInfo.position, generatorInfo.size);
        }
        // -----------------------------------------------------------------------------------

        // 월드상에 존재하는 몬스터 수는 전체수에서 풀링에 담아논 개수에 뺀 결과와 같습니다.
        curPoolCount = keepPoolCount - pool.ObjectPool.Count;
    }

    private void Update()
    {
        // 월드상에 존재하는 몬스터 수는 전체수에서 풀링에 담아논 개수에 뺀 결과와 같습니다.
        curPoolCount = keepPoolCount - pool.ObjectPool.Count;

        // 더한 값이 전체 몬스터 수보다 작을 경우 리스폰을 합니다. ---------
        if (resurveCount + curPoolCount < keepPoolCount)
            StartCoroutine(RespawnAsync());
        // -------------------------------------------------------------
    }

    // 시간을 지연하여 리스폰을 합니다.
    private IEnumerator RespawnAsync()
    {
        // 예약 몬스터 개수 증가
        resurveCount++;

        // 해당 시간만큼 지연합니다.
        yield return new WaitForSeconds(generatorInfo.respawnTime);

        // 풀링을 활성화시킵니다.
        var obj = pool.DeQueue();
        obj.transform.position = generateBehaviour.getGenerate(generatorInfo.position, generatorInfo.size);

        // 예약 몬스터 개수 감소
        resurveCount--;
    }

    public GenerateBehaviour GenerateBehaviour { set { generateBehaviour = value; } }
}
