using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어입니다.
/// </summary>
public class Player : Character
{
    private void Start()
    {
        var mainCam = Camera.main.GetComponent<MainCameraController>() ?? Camera.main.GetComponent<MainCameraController>();

        if(mainCam)
            mainCam.standardObject = gameObject;
    }
}
