using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���͸� �����ϴ� ��Ʈ�ѷ��Դϴ�.
/// </summary>
public class MonsterController : MonoBehaviour, IHealth
{
    /// <summary>
    /// �ش� ���� ����Դϴ�.
    /// </summary>
    public Monster target;

    // �ش� ����� ������ ���Դϴ�.
    [SerializeField]
    private CharacterInfo data;

    [SerializeField]
    private ObjectMoveAI objectMoveAi;
    private void OnEnable()
    {
        // �����͸� �н��ϴ�.
        DataLoad();
    }

    // �����͸� �н��ϴ�.
    private void DataLoad()
    {
        if(target)
            data = MonsterDatabase.SearchData(target.Id);
    }

    // �ش� �÷��̾ �����մϴ�.
    private void Control()
    {
        if (!objectMoveAi)
            return;

        var p = objectMoveAi.Points[objectMoveAi.CurPartIndex];
        target.transform.LookAt(new Vector3(p.x, target.transform.position.y, p.z));
        target.Move(data.speed);
    }

    private void FixedUpdate()
    {
        if (data.hp == 0)
            target.Die();
        else
            // �ش� ����� �����մϴ�.
            Control();
    }

    /// <summary>
    /// �������� �Խ��ϴ�.
    /// </summary>
    /// <param name="damage">������ ��</param>
    public void Damage(int damage)
    {
        if (data != null)
            data.hp = HealthSystem.Damage(data.hp, data.maxHp, damage);
    }
}
