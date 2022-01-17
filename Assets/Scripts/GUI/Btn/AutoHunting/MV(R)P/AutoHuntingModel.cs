using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 자동 사냥 버튼의 데이터 부분입니다.
/// </summary>
public class AutoHuntingModel
{
    // 자동 사냥 데이터입니다.
    private AutoHuntingData autoHuntingData;

    public AutoHuntingModel() => autoHuntingData = (AutoHuntingData)Resources.Load("Datas/ScriptableObjects/AutoHunting/AutoHunting Data");

    // 자동 사냥 데이터입니다.
    public AutoHuntingData AutoHuntingData { get => autoHuntingData;}
}
