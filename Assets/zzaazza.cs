using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zzaazza : MonoBehaviour
{
    [SerializeField] private Pool pool;

    private void Start() => pool.Init();

    public void Active(Collider other)
    {
        pool.DeQueue()?.GetComponent<HitParticle>()?.Active(other);
    }
}
