using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopupView : MonoBehaviour
{
    // Ǯ�� �� ������Ʈ�Դϴ�.
    private PoolableObject poolableObject;

    [SerializeField]
    private TextMeshProUGUI tmp;

    private void Awake()
    {
        poolableObject = GetComponent<PoolableObject>();
    }

    /// <summary>
    /// ������ ���� �ٲߴϴ�.
    /// </summary>
    /// <param name="text">������ ��</param>
    public void ChangeText(string text)
    {
        if (tmp != null)
            tmp.text = text;
    }

    /// <summary>
    /// ��Ȱ��ȭ��ŵ�ϴ�.
    /// </summary>
    public void Disable()
    {
        if(poolableObject != null)
            poolableObject.EnQueue();
    }
}
