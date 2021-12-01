using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 공격 범위를 제어하는 컨트롤러입니다.
/// </summary>
public class AttackRangeController : MonoBehaviour
{
    // 캐릭터를 참조합니다.
    [SerializeField]
    private Character character;

    /// <summary>
    /// 해당 공격 범위입니다.
    /// </summary>
    public GameObject target;

    private void Start()
    {
        target = Instantiate(target, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        Control();
    }

    // 해당 공격 범위를 제어합니다.
    public void Control()
    {
        if (!character || !target)
            return;

        // 공격 범위를 활성화/ 비활성화 시킵니다.
        if (character.stateType == Character.StateTypes.Idle)
        {
            if(!target.activeSelf)
                target.SetActive(true);

            target.transform.position = new Vector3(character.transform.position.x, 0, (character.transform.position.z));
        }
        else if (character.stateType == Character.StateTypes.Move)
            if (target.activeSelf)
                target.SetActive(false);
    }
}
