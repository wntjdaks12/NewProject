using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopupView : MonoBehaviour
{
    // Ǯ���� ������Ʈ�Դϴ�.
    private PoolableObject poolableObject;

    private TextMeshProUGUI tmp;

    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();

        poolableObject = GetComponent<PoolableObject>();
    }

    public void ChangeText(string text)
    {
        if (tmp != null)
            tmp.text = text;
    }

    public void Disable()
    {
        if(poolableObject != null)
            poolableObject.EnQueue();
    }
}
