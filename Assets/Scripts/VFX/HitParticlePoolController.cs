using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ÿ�� ��ƼŬ ������Ʈ Ǯ�� �������Դϴ�.
/// </summary>
public class HitParticlePoolController : MonoBehaviour
{
    // ���� Ÿ�� ��ƼŬ�� ����ϹǷ� Ǯ���� ����մϴ�.
    [SerializeField] private Pool pool;

    private List<HitParticle> particles;

    private void Awake() => particles = new List<HitParticle>();

    private void Start()
    {
        if(pool != null) pool.Init();
    }

    // �ش� Ǯ�� ������Ʈ�� Ȱ��ȭ��ŵ�ϴ�.
    public void Active(GameObject other) => pool.DeQueue()?.GetComponent<HitParticle>()?.Active(other);
}
