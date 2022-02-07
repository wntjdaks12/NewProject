using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 드랍 행위입니다.
/// </summary>
public interface DropBehaviour
{
    // 드랍합니다.
    public void Drop(int amount);
}
