using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 데미지 값을 띄어주는 팝업입니다.
/// </summary>
public class DamagePopup : MonoBehaviour
{
    // 데미지 값을 수시적으로 표현하기 위해 오브젝트 풀링을 사용합니다. -----------------
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
        // 풀링을 초기화시킵니다. ---------------------
        if (_pool != null)
            _pool.Init(transform.root);
        // --------------------------------------------
    }

    /// <summary>
    /// 데미지를 띄웁니다.
    /// </summary>
    /// <param name="damageNum">데미지 값</param>
    /// <param name="vec3">생성 위치 값</param>
    public static void Popup(int damageNum, Vector3 vec3)
    {
        if (_pool == null)
            return;

        // 생성할 위치에 데미지 값을 보여줍니다. ---------------------------------------------------
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
