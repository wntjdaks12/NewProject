using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrail : MonoBehaviour
{
    public float keepTime;

    private Transform parent;

    public void Keep()
    {
        parent = transform.parent;

        transform.parent = null;

        Invoke("Destroy", keepTime);
    }

    public void Destroy() 
    {
        transform.parent = parent;
    }
}
