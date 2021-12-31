using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ownerIds { monster001, monster002 }

public class LootBox : MonoBehaviour
{
    private OwnerInfo ownerInfo;

    public ownerIds ownerId;

    private void OnEnable()
    {
        ownerInfo = LootDatabase.SearchData(ownerId.ToString());
    }

    public void Open()
    {
        foreach (LootInfo data in ownerInfo.lootInfos)
        {
            var rand = Random.Range(1, 101);

            if (rand <= data.probability)
                Instantiate(Resources.Load("Loot/" + data.keyName), transform.transform.position, Quaternion.identity);
        }
    }
}
