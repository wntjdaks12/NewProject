using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Stage2Info
{
    [HideInInspector]
    public string id;
    [HideInInspector]
    public string image;
    [HideInInspector]
    public string keyName;

    public Stage2Info(string id, string image, string keyName)
    {
        this.id = id;
        this.image = image;
        this.keyName = keyName;
    }
}

[System.Serializable]
public class StageInfo
{
    [HideInInspector]
    public string id;
    public List<Stage2Info> stage2Info = new List<Stage2Info>();

    public StageInfo(string id, List<Stage2Info> stage2Info)
    {
        this.id = id;
        this.stage2Info = stage2Info;   
    }
}

public class StageInfos
{
    public List<StageInfo> stageInfos = new List<StageInfo>();
}

public class StageDataBase : MonoBehaviour
{
    private static StageInfos datas;

    private void Start() => LoadData();

    private void LoadData()
    {
        if (!new FileInfo(Application.persistentDataPath + "Stages.json").Exists)
        {
          //  datas = new StageInfos();
          //  datas.stageInfos = new List<StageInfo>();
          //  var a = new List<Stage2Info>();
          //  a.Add(new Stage2Info("stage1_1_001", "iamge"));
          //  datas.stageInfos.Add(new StageInfo("stage1_001", a));
           // File.WriteAllText(Application.persistentDataPath + "Stages.json", JsonUtility.ToJson(datas));
            return;
        }

        // 해당 경로의 제이슨 데이터를 읽고 오브젝트형으로 변환합니다. ---------------------------------------
        var dataStr = File.ReadAllText(Application.persistentDataPath + "Stages.json");
        datas = JsonUtility.FromJson<StageInfos>(dataStr);
        // ------------------------------------------------------------------------------------------------
    }

    public static StageInfo SearchData(string id)
    {
        if (datas == null) return null;

        foreach (StageInfo data in datas.stageInfos)
        {
            if (id == data.id)
                return data;
        }

        return null;
    }
}
