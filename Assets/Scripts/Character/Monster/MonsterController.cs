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
    private MonsterData data;

    [SerializeField]
    private ObjectAI objectAI;

    // �����͸� �н��ϴ�.
    private void OnEnable() => DataLoad();       

    private void Start()
    {
      //  this.UpdateAsObservable()
    }

    // �����͸� �н��ϴ�.
    private void DataLoad()
    {
        if (target && data)
            data.DataLoad(target.Id);
    }

    // �ش� �÷��̾ �����մϴ�.
    private void Control()
    {
        if (data == null || data.Data == null)
            return;

        if (!objectAI) return;

        // �̵��� ��ġ�� ���� ��ġ�� �̿��Ͽ� ������ ���ϰ� �̵��� ��ŵ�ϴ�.
        var dir = objectAI.DirectionBehaviour.getDirection(transform.position); dir.y = 0f;
        target.Move(dir, data.Data.speed);
    }

    private void Update()
    {
        if (data == null || data.Data == null)
            return;

        if (data.Data.hp <= 0)
            target.Die();
    }

    private void FixedUpdate()
    {
        // �ش� ����� �����մϴ�.
        Control();
    }

    /// <summary>
    /// �������� �Խ��ϴ�.
    /// </summary>
    /// <param name="damage">������ ��</param>
    public void Damage(GameObject other, int damage)
    {
        if (data != null && data.Data != null)
            data.Data.hp = HealthSystem.Damage(data.Data.hp, data.Data.maxHp, damage);

        if (objectAI)
            objectAI.DirectionBehaviour = new ObjectAITraceDirection(other);

        DamagePopup.Popup(damage, Camera.main.WorldToScreenPoint(target.transform.position));
    }

    private void asd()
    {
        
    }

    public MonsterData Data { get { return data; } }
}
