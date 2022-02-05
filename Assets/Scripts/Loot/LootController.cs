using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootController : MonoBehaviour
{
    [SerializeField] private Pool pool;

    private void Start()
    {
        pool.Init();
    }
}
