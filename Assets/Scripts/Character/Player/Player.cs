using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾��Դϴ�.
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
