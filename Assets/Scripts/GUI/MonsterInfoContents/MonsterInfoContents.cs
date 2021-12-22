using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���� ���� �������Դϴ�.
/// </summary>
public class MonsterInfoContents : MonoBehaviour
{
    // ����, ü���� ��Ÿ���� ���� �ؽ�Ʈ�Դϴ�.
    [SerializeField]
    private Text lvText, hpText;

    // ü���� �� ���Ʈ�� �����մϴ�.
    [SerializeField]
    private Image hpImg;

    // ���� ��ġ�� �����ϱ� ���� ��Ʈ Ʈ�������� �����ɴϴ�.
    private RectTransform rectTs;

    private void Awake()
    {   
        rectTs = GetComponent<RectTransform>();
    }

    /// <summary>
    /// ü���� �����մϴ�.
    /// </summary>
    /// <param name="hp">���� ü��</param>
    /// <param name="maxHp">�ִ� ü��</param>
    public void setHp(int hp, int maxHp)
    {
        // ü���� �ؽ�Ʈ�� ǥ���մϴ�.
        hpText.text = hp.ToString() + " / " + maxHp;

        // ü���� �̹����� ǥ���մϴ�.
        hpImg.fillAmount = (float) hp / maxHp;
    }

    /// <summary>
    /// ������ �����մϴ�.
    /// </summary>
    /// <param name="lv">���� ����</param>
    public void setLv(int lv)
    {
        lvText.text = lv.ToString();
    }

    /// <summary>
    /// �ش� ��ġ�� �̵���ŵ�ϴ�.
    /// </summary>
    /// <param name="vec3">�̵��� ��ġ ��</param>
    public void Move(Vector3 vec3)
    {
        // �ش� ��ġ�� �̵��մϴ�.
        if(rectTs)
            rectTs.position = vec3;
    }
}
