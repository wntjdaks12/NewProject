using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ownerIds { monster001, monster002 }

/// <summary>
/// 전리품을 생성하게 해주는 상자입니다.
/// </summary>
public class LootBox : MonoBehaviour
{
    private OwnerInfo ownerInfo;

    public ownerIds ownerId;

    private Dictionary<string, Pool> poolDict = new Dictionary<string, Pool>();

    private void Start()
    {
        ownerInfo = LootDatabase.SearchData(ownerId.ToString());

        Init();
    }

    private void Init()
    {
        foreach (LootInfo data in ownerInfo.lootInfos)
        {
            var obj = Instantiate(Resources.Load("Loot/" + data.keyName)) as GameObject;

            poolDict.Add(data.keyName, obj.GetComponent<Pool>());
        }
    }

    public void Open()
    {
        foreach (LootInfo data in ownerInfo.lootInfos)
        {
            var rand = Random.Range(1, 101);

            if (rand <= data.probability)
            {
                var obj =  poolDict[data.keyName].DeQueue();
                obj.transform.position = transform.position;
            }
        }
    }
}
