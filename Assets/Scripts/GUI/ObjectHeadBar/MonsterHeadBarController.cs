using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ��ܹٸ� �����ϴ� ��Ʈ�ѷ��Դϴ�.
/// </summary>
public class MonsterHeadBarController : MonoBehaviour
{
    /// <summary>
    /// ���� ��ܹٸ� �����մϴ�.
    /// </summary>
    public ObjectHeadBarView objectHeadBarView;

    /// <summary>
    /// �ش� ��ܹ��� ��ġ�� �����ϱ� �����ɴϴ�.
    /// </summary>
    public Transform targetTs;

    // �ش� ��ܹ��� �������Դϴ�.
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

        // �ش� �������� �����ϰ� UI ����̹Ƿ� ĵ���� ������ �����մϴ�.
        objectHeadBarView = Instantiate(objectHeadBarView, GameObject.Find("Canvas").transform);

        objectHeadBarView.ObjectHeadBarPresenter = new ObjectHeadBarPresenter(objectHeadBarView, model);
    }

    private void Update()
    {
        if (objectHeadBarView == null)
            return;

        // �ش� �������� HP�� �����մϴ�. -------------------------------------------------------
        if (monsterData != null && monsterData.Data != null)
            objectHeadBarView.ChangeHp();
        // -------------------------------------------------------------------------------------
    }

    private void LateUpdate()
    {
        if (objectHeadBarView == null)
            return;

        // �ش� �������� ��ġ�� �����մϴ�. -------------------------------------------------------------
        if (targetTs != null)
            objectHeadBarView.Move(Camera.main.WorldToScreenPoint(targetTs.position));
        // ---------------------------------------------------------------------------------------------
    }

    private void OnDisable()
    {
        if (objectHeadBarView == null)
            return;

        // ��Ȱ��ȭ �� HP üũ�� �ȵǹǷ� ���������� HP�� �� �� �� �����մϴ�. --------------------------------------------------
        if (monsterData != null && monsterData.Data != null)
            objectHeadBarView.ChangeHp();
        // -----------------------------------------------------------------------------------------
    }
}
