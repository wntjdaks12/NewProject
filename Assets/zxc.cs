using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zxc : MonoBehaviour
{
    [SerializeField] private Pool pool;

    private void Start()
    {
        pool.Init();
    }
}
