using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// 플레이어 데이터 정보입니다.
/// </summary>
public class PlayerInfo
{
    /// <summary>
    /// 이동 속도입니다.
    /// </summary>
    public float speed;

    public PlayerInfo(float speed)
    {
        this.speed = speed;
    }
}

/// <summary>
/// 플레이어 데이터베이스입니다.
/// </summary>
[System.Serializable]
public class PlayerDatabase : MonoBehaviour
{
    // 플레이어 데이터입니다.
    private PlayerInfo data;

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
        // 해당 경로의 제이슨 데이터를 읽고 오브젝트형으로 변환합니다. ---------------------------------------
        var dataStr = File.ReadAllText(Application.dataPath + "/Datas/Jsons/CharacterData.json");
        data = JsonUtility.FromJson<PlayerInfo>(dataStr);
        // ------------------------------------------------------------------------------------------------
        
        // 스크립터블 데이터에 저장합니다. -----------------------------
        playerData.Speed = data.speed;
        // ------------------------------------------------------------
    }
}
