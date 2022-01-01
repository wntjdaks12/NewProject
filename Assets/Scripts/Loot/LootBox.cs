using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ownerIds { monster001, monster002 }

/// <summary>
/// 전리품을 생성하게 해주는 상자입니다.
/// </summary>
public class LootBox : MonoBehaviour
{
    // 소유자 전리품 정보입니다.
    private OwnerInfo ownerInfo;

    // 소유자 ID 값입니다.
    private ownerIds ownerId;

    // 해당 ID 값을 가진 전리품을 풀링 시키기 위한 딕셔너리입니다.
    private Dictionary<string, Pool> poolDict = new Dictionary<string, Pool>();

    private void Start()
    {
        ownerInfo = LootDatabase.SearchData(ownerId.ToString());

        Init();
    }

    /// <summary>
    /// 초기화시킵니다.
    /// </summary>
    private void Init()
    {
        // 풀링할 전리품을 캐싱합니다. ----------------------------------------------------------------------
        foreach (LootInfo data in ownerInfo.lootInfos)
        {
            var obj = Instantiate(Resources.Load("Loot/" + data.keyName)) as GameObject;

            poolDict.Add(data.keyName, obj.GetComponent<Pool>());
        }
        // -------------------------------------------------------------------------------------------------
    }

    /// <summary>
    /// 전리품 상자를 오픈합니다.
    /// </summary>
    public void Open()
    {
        // 확률에 따른 전리품을 풀링합니다. ---------------------------------
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
