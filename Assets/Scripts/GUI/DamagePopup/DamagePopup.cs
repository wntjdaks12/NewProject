using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ ���� ����ִ� �˾��Դϴ�.
/// </summary>
public class DamagePopup : MonoBehaviour
{
    // ������ ���� ���������� ǥ���ϱ� ���� ������Ʈ Ǯ���� ����մϴ�. -----------------
    [SerializeField]
    private Pool pool;
    private static Pool _pool;
    // ---------------------------------------------------------------------------

    private void Awake()
    {
        _pool = pool;
    }

    public void Start()
    {
        // Ǯ���� �ʱ�ȭ��ŵ�ϴ�. ---------------------
        if (_pool != null)
            _pool.Init(transform.root);
        // --------------------------------------------
    }

    /// <summary>
    /// �������� ���ϴ�.
    /// </summary>
    /// <param name="damageNum">������ ��</param>
    /// <param name="vec3">���� ��ġ ��</param>
    public static void Popup(int damageNum, Vector3 vec3)
    {
        if (_pool == null)
            return;

        // ������ ��ġ�� ������ ���� �����ݴϴ�. ---------------------------------------------------
        var obj = _pool.DeQueue();

        if (obj != null)
        {
            if (obj.GetComponent<DamagePopupView>() != null)
            {
                obj.GetComponent<DamagePopupView>().ChangeText(damageNum.ToString());
                obj.transform.position = vec3;
            }
        }
        // -------------------------------------------------------------------------------------
    }
}
