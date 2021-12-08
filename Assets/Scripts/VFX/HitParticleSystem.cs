using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ÿ�� ����Ʈ�� �������Դϴ�.
/// </summary>
public class HitParticleSystem : MonoBehaviour
{
    /// <summary>
    /// �ش� ��ƼŬ�� ���ӽð��Դϴ�.
    /// </summary>
    public float lifeTime;

    // ������ �ֻ��� ��ü�Դϴ�.
    private Transform parent;

    // ��ƼŬ �ý����� �����մϴ�.
    private ParticleSystem ps;

    private void Start()
    {
        parent = transform.root;

        ps = GetComponent<ParticleSystem>() ?? GetComponent<ParticleSystem>();
    }

    /// <summary>
    /// Ÿ�� ����Ʈ�� Ȱ��ȭ��ŵ�ϴ�.
    /// </summary>
    /// <param name="other">�浹 ���</param>
    public void Active(Collider other)
    {
        if (!ps)
            return;
     
        // �浹�� ��� ������ Ÿ�� ����Ʈ�� �����ϴ�. ----------------------
        transform.parent = other.transform;
        transform.localPosition = new Vector3(0, 0, 0);
        // ----------------------------------------------------------------

        // ��ƼŬ�� �����մϴ�.
        ps.Play();

        // ���ӽð��� ���� ��ƼŬ�� ��Ȱ��ȭ��ŵ�ϴ�.
        Invoke("Deactive", lifeTime);
    }

    /// <summary>
    /// Ÿ�� ��ƼŬ ��Ȱ��ȭ��ŵ�ϴ�.
    /// </summary>
    public void Deactive()
    {
        // ���� ��ü�� ��Ӱ��踦 �����մϴ�.
        transform.parent = parent;
    }
}
