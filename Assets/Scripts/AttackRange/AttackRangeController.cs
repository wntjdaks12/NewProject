using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ������ �����ϴ� ��Ʈ�ѷ��Դϴ�.
/// </summary>
public class AttackRangeController : MonoBehaviour
{
    // ĳ���͸� �����մϴ�.
    [SerializeField]
    private Character character;

    /// <summary>
    /// �ش� ���� �����Դϴ�.
    /// </summary>
    public GameObject target;

    private void Update()
    {
        Control();
    }

    // �ش� ���� ������ �����մϴ�.
    public void Control()
    {
        if (!character || !target)
            return;

        // ���� ������ Ȱ��ȭ/ ��Ȱ��ȭ ��ŵ�ϴ�.
        if (!target.activeSelf && character.stateType == Character.StateTypes.Idle)
        {
            target.SetActive(true);

            target.transform.position = new Vector3(character.transform.position.x, 0, (character.transform.position.z));
        }
        else if (target.activeSelf && character.stateType == Character.StateTypes.Move)
            target.SetActive(false);
    }
}
