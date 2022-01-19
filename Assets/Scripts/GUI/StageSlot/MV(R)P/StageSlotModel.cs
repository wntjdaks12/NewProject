using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 스테이지 슬롯의 데이터 부분입니다.
/// </summary>
public class StageSlotModel
{   
    // 스테이지 데이터입니다.
    private StageData data;

    public StageSlotModel() => data = (StageData)Resources.Load("Datas/ScriptableObjects/Stage/Stage Data");

    // 스테이지 데이터입니다.
    public StageData Data { get => data; }
}
