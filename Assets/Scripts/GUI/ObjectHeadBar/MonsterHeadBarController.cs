using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using UniRx;

/// <summary>
/// ���� ��� �ٸ� �����ϴ� ��Ʈ�ѷ��Դϴ�.
/// </summary>
public class MonsterHeadBarController : MonoBehaviour
{
    /// <summary>
    /// ��� �� ��� ���� �����ɴϴ�.
    /// </summary>
    public ObjectHeadBar objectHeadBar;

    /// <summary>
    /// �ش� ��� ���� ��ġ�� �����ϱ� ���� �����ɴϴ�.
    /// </summary>
    public Transform targetTs;

    // �ش� ��� ���� �������Դϴ�.
    [SerializeField]
    private MonsterData monsterData;

    private void Start()
    {
        if (targetTs == null) return;

        if (objectHeadBar == null) return;

        if (GameObject.Find("Canvas") == null) return;

        // �ش� ��� �ٸ� �����ϰ� UI ����̹Ƿ� ĵ���� ������ �����մϴ�.
        var obj = Instantiate(objectHeadBar.gameObject, GameObject.Find("Canvas").transform);

        // ��� �� �����͸� ���� �����ͷ� �����մϴ�. -----------------------------------
        if (monsterData != null)
        {
            var model = new MonsterHeadBarModel();
            model.MonsterData = monsterData;
            obj.GetComponent<ObjectHeadBarPresenter>().Model = model;
        }
        // -----------------------------------------------------------------------------

        objectHeadBar = obj.GetComponent<ObjectHeadBar>();

        // ��� �ٸ� �ش� Ÿ���� ��ġ�� ���󰡰� ���ִ� ������Ʈ ��Ʈ���Դϴ�.
        this.LateUpdateAsObservable().Subscribe(_ => objectHeadBar.Move(Camera.main.WorldToScreenPoint(targetTs.position)));
    }
}