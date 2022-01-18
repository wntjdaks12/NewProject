using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private StageData data;

    private void Start()
    {
        var data = StageDataBase.SearchData("stage1_001");

        this.data.stageInfo = data;
    }
}
