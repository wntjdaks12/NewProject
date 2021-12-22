using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 몬스터 정보 컨텐츠를 제어하는 컨트롤러입니다.
/// </summary>
public class MonsterInfoContentsController : MonoBehaviour
{
    /// <summary>
    /// 몬스터 정보 컨텐츠를 제어합니다.
    /// </summary>
    public MonsterInfoContents monsterinfoContents;

    /// <summary>
    /// 해당 컨텐츠의 위치를 지정하기 가져옵니다.
    /// </summary>
    public Transform targetTs;

    // 몬스터 정보를 보여주기 위한 데이터입니다.
    [SerializeField]
    private MonsterData monsterData;

    private void Start()
    {
        if (monsterinfoContents == null)
            return;

        // 해당 컨텐츠를 생성하고 UI 요소이므로 캔버스 하위로 지정합니다.
        monsterinfoContents = Instantiate(monsterinfoContents, GameObject.Find("Canvas").transform);

        // 해당 컨텐츠의 레벨을 설정합니다.
        if (monsterData != null && monsterData.Data != null)
            monsterinfoContents.setLv(monsterData.Data.lv);
    }

    private void Update()
    {
        if (monsterinfoContents == null)
            return;

        // 해당 컨텐츠의 HP를 갱신합니다. -------------------------------------------------------
        if(monsterData != null && monsterData.Data != null)
            monsterinfoContents.setHp(monsterData.Data.hp, monsterData.Data.maxHp);
        // -------------------------------------------------------------------------------------
    }

    private void LateUpdate()
    {
        if (monsterinfoContents == null)
            return;

        // 해당 컨텐츠의 위치를 갱신합니다. -------------------------------------------------------------
        if (targetTs != null)
            monsterinfoContents.Move(Camera.main.WorldToScreenPoint(targetTs.position));
        // ---------------------------------------------------------------------------------------------
    }

    private void OnDisable()
    {
        if (monsterinfoContents == null)
            return;

        // 비활성화 시 HP 체크가 안되므로 마지막으로 HP를 한 번 더 갱신합니다. --------------------------------------------------
        if (monsterData != null && monsterData.Data != null)
            monsterinfoContents.setHp(monsterData.Data.hp, monsterData.Data.maxHp);
        // -----------------------------------------------------------------------------------------
    }
}
