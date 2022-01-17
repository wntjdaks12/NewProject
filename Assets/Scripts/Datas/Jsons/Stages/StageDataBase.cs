using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class StageInfo
{
    [HideInInspector]
    public string id;
    [HideInInspector]
    public string image;

    public StageInfo(string id, string image)
    {
        this.id = id;
        this.image = image;
    }
}

public class StageInfos
{
    public List<StageInfo> stageInfos;
}

public class StageDataBase : MonoBehaviour
{
    private static StageInfos datas;

    private void Start() => LoadData();

    private void LoadData()
    {
        if (!new FileInfo(Application.persistentDataPath + "Stages.json").Exists)
            return;

        // 해당 경로의 제이슨 데이터를 읽고 오브젝트형으로 변환합니다. ---------------------------------------
        var dataStr = File.ReadAllText(Application.persistentDataPath + "Stages.json");
        datas = JsonUtility.FromJson<StageInfos>(dataStr);
        // ------------------------------------------------------------------------------------------------
    }

    public static StageInfo SearchData(string id)
    {
        if (datas == null)
            return null;

        foreach (StageInfo data in datas.stageInfos)
        {
            if (id == data.id)
                return data;
        }

        return null;
    }

    public static StageInfo DeepCopy(StageInfo data)
    {
        StageInfo stageInfo = new StageInfo(
            data.id,
            data.image
        );

        return stageInfo;
    }
}
