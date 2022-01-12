using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 타격 파티클 오브젝트 풀링 제어자입니다.
/// </summary>
public class HitParticlePoolController : MonoBehaviour
{
    // 많은 타격 파티클을 사용하므로 풀링을 사용합니다.
    [SerializeField] private Pool pool;

    private List<HitParticle> particles;

    private void Awake() => particles = new List<HitParticle>();

    private void Start()
    {
        if(pool != null) pool.Init();
    }

    // 해당 풀링 오브젝트를 활성화시킵니다.
    public void Active(GameObject other) => pool.DeQueue()?.GetComponent<HitParticle>()?.Active(other);
}
