using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// 플레이어 데이터 정보입니다.
/// </summary>
[System.Serializable]
public class PlayerInfo
{
    public CharacterInfo characterInfo;

    public PlayerInfo(CharacterInfo characterInfo)
    {
        this.characterInfo = characterInfo;
    }
}

/// <summary>
/// 플레이어 데이터베이스입니다.
/// </summary>
public class PlayerDatabase : CharacterDatabase
{
    // 플레이어 스크립터블 데이터입니다.
    [SerializeField]
    private PlayerData playerData;

    private void Start()
    {
        // 데이터를 읽습니다.
        LoadData();
    }

    // 데이터를 읽습니다.
    private void LoadData()
    {
        // // 해당 경로에 있는 제이슨 데이터를 체크합니다.
        if (!new FileInfo(Application.dataPath + "/Datas/Jsons/Player/Player.json").Exists)
            return;
            
        // 해당 경로의 제이슨 데이터를 읽고 오브젝트형으로 변환합니다. ---------------------------------------
        var dataStr = File.ReadAllText(Application.dataPath + "/Datas/Jsons/Player/Player.json");
        datas = JsonUtility.FromJson<CharacterInfos>(dataStr);
        // ------------------------------------------------------------------------------------------------
    }
}
