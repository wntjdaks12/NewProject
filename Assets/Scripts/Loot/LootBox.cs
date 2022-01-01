using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ownerIds { monster001, monster002 }

/// <summary>
/// ����ǰ�� �����ϰ� ���ִ� �����Դϴ�.
/// </summary>
public class LootBox : MonoBehaviour
{
    // ������ ����ǰ �����Դϴ�.
    private OwnerInfo ownerInfo;

    // ������ ID ���Դϴ�.
    private ownerIds ownerId;

    // �ش� ID ���� ���� ����ǰ�� Ǯ�� ��Ű�� ���� ��ųʸ��Դϴ�.
    private Dictionary<string, Pool> poolDict = new Dictionary<string, Pool>();

    private void Start()
    {
        ownerInfo = LootDatabase.SearchData(ownerId.ToString());

        Init();
    }

    /// <summary>
    /// �ʱ�ȭ��ŵ�ϴ�.
    /// </summary>
    private void Init()
    {
        // Ǯ���� ����ǰ�� ĳ���մϴ�. ----------------------------------------------------------------------
        foreach (LootInfo data in ownerInfo.lootInfos)
        {
            var obj = Instantiate(Resources.Load("Loot/" + data.keyName)) as GameObject;

            poolDict.Add(data.keyName, obj.GetComponent<Pool>());
        }
        // -------------------------------------------------------------------------------------------------
    }

    /// <summary>
    /// ����ǰ ���ڸ� �����մϴ�.
    /// </summary>
    public void Open()
    {
        // Ȯ���� ���� ����ǰ�� Ǯ���մϴ�. ---------------------------------
        foreach (LootInfo data in ownerInfo.lootInfos)
        {
            var rand = Random.Range(1, 101);

            if (rand <= data.probability)
            {
                var obj =  poolDict[data.keyName].DeQueue();
                obj.transform.position = transform.position;
            }
        }
        // -----------------------------------------------------------------
    }
}
