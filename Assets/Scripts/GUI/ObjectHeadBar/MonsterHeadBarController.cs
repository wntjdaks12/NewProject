using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 몬스터 상단바를 제어하는 컨트롤러입니다.
/// </summary>
public class MonsterHeadBarController : MonoBehaviour
{
    /// <summary>
    /// 몬스터 상단바를 제어합니다.
    /// </summary>
    public ObjectHeadBarView objectHeadBarView;

    /// <summary>
    /// 해당 상단바의 위치를 지정하기 가져옵니다.
    /// </summary>
    public Transform targetTs;

    // 해당 상단바의 데이터입니다.
    [SerializeField]
    private MonsterData monsterData;

    private void Start()
    {
        if (monsterData == null)
            return;

        var model = new MonsterHeadBarModel();
        model.MonsterData = monsterData;

        if (objectHeadBarView == null)
            return;

        // 해당 컨텐츠를 생성하고 UI 요소이므로 캔버스 하위로 지정합니다.
        objectHeadBarView = Instantiate(objectHeadBarView, GameObject.Find("Canvas").transform);

        objectHeadBarView.ObjectHeadBarPresenter = new ObjectHeadBarPresenter(objectHeadBarView, model);
    }

    private void Update()
    {
        if (objectHeadBarView == null)
            return;

        // 해당 컨텐츠의 HP를 갱신합니다. -------------------------------------------------------
        if (monsterData != null && monsterData.Data != null)
            objectHeadBarView.ChangeHp();
        // -------------------------------------------------------------------------------------
    }

    private void LateUpdate()
    {
        if (objectHeadBarView == null)
            return;

        // 해당 컨텐츠의 위치를 갱신합니다. -------------------------------------------------------------
        if (targetTs != null)
            objectHeadBarView.Move(Camera.main.WorldToScreenPoint(targetTs.position));
        // ---------------------------------------------------------------------------------------------
    }

    private void OnDisable()
    {
        if (objectHeadBarView == null)
            return;

        // 비활성화 시 HP 체크가 안되므로 마지막으로 HP를 한 번 더 갱신합니다. --------------------------------------------------
        if (monsterData != null && monsterData.Data != null)
            objectHeadBarView.ChangeHp();
        // -----------------------------------------------------------------------------------------
    }
}
