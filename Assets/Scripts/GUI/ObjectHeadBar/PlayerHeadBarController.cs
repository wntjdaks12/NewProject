using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using UniRx;

public class PlayerHeadBarController : MonoBehaviour
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
    private PlayerData playerData;

    private void Start()
    {
        if (targetTs == null) return;

        if (objectHeadBar == null) return;

        if (GameObject.Find("Canvas") == null) return;

        // �ش� ��� �ٸ� �����ϰ� UI ����̹Ƿ� ĵ���� ������ �����մϴ�.
        var obj = Instantiate(objectHeadBar.gameObject, GameObject.Find("Canvas").transform);

        // ��� �� �����͸� ���� �����ͷ� �����մϴ�. -----------------------------------
        if (playerData != null)
        {
            var model = new PlayerHeadBarModel();
            model.PlayerData = playerData;
            obj.GetComponent<ObjectHeadBarPresenter>().Model = model;
        }
        // -----------------------------------------------------------------------------

        objectHeadBar = obj.GetComponent<ObjectHeadBar>();

        // ��� �ٸ� �ش� Ÿ���� ��ġ�� ���󰡰� ���ִ� ������Ʈ ��Ʈ���Դϴ�.
        this.LateUpdateAsObservable().Subscribe(_ => objectHeadBar.Move(Camera.main.WorldToScreenPoint(targetTs.position)));
    }
}
