using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���͸� �����ϴ� ��Ʈ�ѷ��Դϴ�.
/// </summary>
public class MonsterController : MonoBehaviour, IDamageable
{
    /// <summary>
    /// �ش� ���� ����Դϴ�.
    /// </summary>
    public Monster target;

    // �ش� ����� ������ ���Դϴ�.
    [SerializeField]
    private CharacterInfo data;

    [SerializeField]
    private ObjectAI objectAI;
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
        if (!objectAI)
            return;

        // �̵��� ��ġ�� ���� ��ġ�� �̿��Ͽ� ������ ���ϰ� �̵��� ��ŵ�ϴ�.
        var dir = objectAI.DirectionBehaviour.getDirection(transform.position); dir.y = 0f;
        target.Move(dir, data.speed);

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
    public void Damage(GameObject other, int damage)
    {
        if (data != null)
            data.hp = HealthSystem.Damage(data.hp, data.maxHp, damage);

        if (objectAI)
            objectAI.DirectionBehaviour = new ObjectAITraceDirection(other);
    }
}
