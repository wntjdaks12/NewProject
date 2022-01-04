using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopupView : MonoBehaviour
{
    // 풀링 할 오브젝트입니다.
    private PoolableObject poolableObject;

    [SerializeField]
    private TextMeshProUGUI tmp;

    private void Awake()
    {
        poolableObject = GetComponent<PoolableObject>();
    }

    /// <summary>
    /// 데미지 값을 바꿉니다.
    /// </summary>
    /// <param name="text">데미지 값</param>
    public void ChangeText(string text)
    {
        if (tmp != null)
            tmp.text = text;
    }

    /// <summary>
    /// 비활성화시킵니다.
    /// </summary>
    public void Disable()
    {
        if(poolableObject != null)
            poolableObject.EnQueue();
    }
}
