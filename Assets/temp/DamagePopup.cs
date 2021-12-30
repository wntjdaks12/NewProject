using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    [SerializeField]
    public Pool pool;
    private static Pool _pool;

    private void Awake()
    {
        _pool = pool;
    }

    public void Start()
    {
        _pool.Init(transform.root);
    }

    public static void Popup(int damageNum, Vector3 vec3)
    {
        if (_pool == null)
            return;

        var obj = _pool.DeQueue();

        if (obj != null)
        {
            obj.GetComponent<DamagePopupView>().ChangeText(damageNum.ToString());
            obj.transform.position = vec3;
        }
    }
}
