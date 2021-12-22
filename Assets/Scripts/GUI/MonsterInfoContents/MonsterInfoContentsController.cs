using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ���� �������� �����ϴ� ��Ʈ�ѷ��Դϴ�.
/// </summary>
public class MonsterInfoContentsController : MonoBehaviour
{
    /// <summary>
    /// ���� ���� �������� �����մϴ�.
    /// </summary>
    public MonsterInfoContents monsterinfoContents;

    /// <summary>
    /// �ش� �������� ��ġ�� �����ϱ� �����ɴϴ�.
    /// </summary>
    public Transform targetTs;

    // ���� ������ �����ֱ� ���� �������Դϴ�.
    [SerializeField]
    private MonsterData monsterData;

    private void Start()
    {
        if (monsterinfoContents == null)
            return;

        // �ش� �������� �����ϰ� UI ����̹Ƿ� ĵ���� ������ �����մϴ�.
        monsterinfoContents = Instantiate(monsterinfoContents, GameObject.Find("Canvas").transform);

        // �ش� �������� ������ �����մϴ�.
        if (monsterData != null && monsterData.Data != null)
            monsterinfoContents.setLv(monsterData.Data.lv);
    }

    private void Update()
    {
        if (monsterinfoContents == null)
            return;

        // �ش� �������� HP�� �����մϴ�. -------------------------------------------------------
        if(monsterData != null && monsterData.Data != null)
            monsterinfoContents.setHp(monsterData.Data.hp, monsterData.Data.maxHp);
        // -------------------------------------------------------------------------------------
    }

    private void LateUpdate()
    {
        if (monsterinfoContents == null)
            return;

        // �ش� �������� ��ġ�� �����մϴ�. -------------------------------------------------------------
        if (targetTs != null)
            monsterinfoContents.Move(Camera.main.WorldToScreenPoint(targetTs.position));
        // ---------------------------------------------------------------------------------------------
    }

    private void OnDisable()
    {
        if (monsterinfoContents == null)
            return;

        // ��Ȱ��ȭ �� HP üũ�� �ȵǹǷ� ���������� HP�� �� �� �� �����մϴ�. --------------------------------------------------
        if (monsterData != null && monsterData.Data != null)
            monsterinfoContents.setHp(monsterData.Data.hp, monsterData.Data.maxHp);
        // -----------------------------------------------------------------------------------------
    }
}
