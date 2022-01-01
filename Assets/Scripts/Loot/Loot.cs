using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����ǰ�Դϴ�.
/// </summary>
public class Loot : MonoBehaviour
{
    // ����ǰ�� ������ ���� ������ٵ� �����ɴϴ�.
    private Rigidbody rigid;

    // ����ǰ�� ���� ������ ���Դϴ�.
    [SerializeField]
    private float throwingPower;

    // ����ǰ�� ���� ���� �ð��Դϴ�.
    [SerializeField]
    private float lifeTime;

    // Ǯ�� �� ������Ʈ�Դϴ�.
    [SerializeField]
    private PoolableObject poolableObject;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Throw();

        StartCoroutine(DestroyAsync());
    }

    /// <summary>
    /// ����ǰ�� �����ϴ�.
    /// </summary>
    private void Throw()
    {
        // ����ǰ�� ������ �������� �����ϴ�. -------------------------------------------------------------------------------------------------------------------
        if (rigid != null)
            rigid.AddForce(new Vector3(Random.Range(-1f, 1f), Random.Range(0, 3f), Random.Range(-1f, 1f)) * throwingPower, ForceMode.Impulse);
        // ----------------------------------------------------------------------------------------------------------------------------------------------------
    }

    /// <summary>
    /// ����ǰ�� ������ŵ�ϴ�.
    /// </summary>
    /// <returns></returns>
    private IEnumerator DestroyAsync()
    {
        // ���� �ð��� ���� �� ������ŵ�ϴ�. -------------------------------
        yield return new WaitForSeconds(lifeTime);
        if(poolableObject != null)
            poolableObject.EnQueue();
        // ---------------------------------------------------------------
    }
}
