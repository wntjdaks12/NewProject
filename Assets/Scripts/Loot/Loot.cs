using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    private Rigidbody rigid;

    [SerializeField]
    private float throwingPower;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        if(rigid != null)
            rigid.AddForce(new Vector3(Random.Range(-1f, 1f), Random.Range(0, 3f), Random.Range(-1f, 1f)) * throwingPower, ForceMode.Impulse);
    }
}
