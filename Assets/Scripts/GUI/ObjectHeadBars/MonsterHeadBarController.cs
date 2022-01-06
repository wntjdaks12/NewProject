using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using UniRx;

/// <summary>
/// 몬스터 상단 바를 제어하는 컨트롤러입니다.
/// </summary>
public class MonsterHeadBarController : MonoBehaviour
{
    /// <summary>
    /// 상단 바 제어를 위해 가져옵니다.
    /// </summary>
    public ObjectHeadBar objectHeadBar;

    /// <summary>
    /// 해당 상단 바의 위치를 지정하기 위해 가져옵니다.
    /// </summary>
    public Transform targetTs;

    // 해당 상단 바의 데이터입니다.
    [SerializeField]
    private MonsterData monsterData;

    private void Start()
    {
        if (targetTs == null) return;

        if (objectHeadBar == null) return;

        if (GameObject.Find("Canvas") == null) return;

        // 해당 상단 바를 생성하고 UI 요소이므로 캔버스 하위로 지정합니다.
        var obj = Instantiate(objectHeadBar.gameObject, GameObject.Find("Canvas").transform);

        // 상단 바 데이터를 몬스터 데이터로 대입합니다. -----------------------------------
        if (monsterData != null)
        {
            var model = new MonsterHeadBarModel();
            model.MonsterData = monsterData;
            obj.GetComponent<ObjectHeadBarPresenter>().Model = model;
        }
        // -----------------------------------------------------------------------------

        objectHeadBar = obj.GetComponent<ObjectHeadBar>();

        // 상단 바를 해당 타겟의 위치를 따라가게 해주는 업데이트 스트림입니다.
        this.LateUpdateAsObservable().Subscribe(_ => objectHeadBar.Move(Camera.main.WorldToScreenPoint(targetTs.position)));
    }
}