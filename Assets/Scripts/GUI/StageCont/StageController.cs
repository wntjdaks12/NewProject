using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;


    private void Start()
    {
        var data = StageDataBase.SearchData("Forest");

        stageData.stageInfo = data;
    }
}
