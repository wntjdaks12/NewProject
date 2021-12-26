using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ������Ʈ ��ܿ� UI�� �����ִ� �κ��Դϴ�.
/// </summary>
public class ObjectHeadBarView : MonoBehaviour
{
    // ���� ��ġ�� �����ϱ� ���� ��Ʈ Ʈ�������� �����ɴϴ�.
    private RectTransform rectTs;

    // ����, ü���� ��Ÿ���� ���� �ؽ�Ʈ�Դϴ�.
    [SerializeField]
    private Text lvText, hpText;

    // ü���� �� ���Ʈ�� �� �Ƹ���Ʈ ������ �����մϴ�.
    [SerializeField]
    private Image hpImg, lerpHpImg;

    // �����͸� �����ϱ� ���� �Ű����� �ν��Ͻ��� �޽��ϴ�.
    private ObjectHeadBarPresenter objectHeadBarPresenter;
/// </summary>
    /// <param name
    private void Awake()
    {
        rectTs = GetComponent<RectTransform>();
    }

    private void Start()
    {
        ChangeHp();
        ChangeLv();
    }

    public void Update()
    {
        if (lerpHpImg && hpImg)
            LerpFillAmount();
    }

    // ü�� ������ �����մϴ�.
    private void LerpFillAmount()
    {
        if (Mathf.Abs(lerpHpImg.fillAmount - hpImg.fillAmount) > 0.01f)
            lerpHpImg.fillAmount = Mathf.Lerp(lerpHpImg.fillAmount, hpImg.fillAmount, Time.deltaTime * 5f);
    }

    /// <summary>
    /// �̵���ŵ�ϴ�.
    /// </summary>
    /// <param name="vec3">�̵��� ��ġ</param>
    public void Move(Vector3 vec3)
    {
        // �ش� ��ġ�� �̵��մϴ�.
        if (rectTs)
            rectTs.position = vec3;
    }

    /// <summary>
    /// ü���� �����մϴ�.
    /// </summary>
    public void ChangeHp()
    {
        if (objectHeadBarPresenter == null)
            return;

        if(hpText)
            hpText.text = objectHeadBarPresenter.Hp + " / " + objectHeadBarPresenter.MaxHp;

        if(hpImg)
            hpImg.fillAmount = (float)objectHeadBarPresenter.Hp / objectHeadBarPresenter.MaxHp;
    }

    /// <summary>
    /// ������ �����մϴ�.
    /// </summary>
    public void ChangeLv()
    {
        if (objectHeadBarPresenter == null)
            return;

        if (lvText)
            lvText.text = objectHeadBarPresenter.Lv.ToString();
    }

    public ObjectHeadBarPresenter ObjectHeadBarPresenter { get => ObjectHeadBarPresenter; set => objectHeadBarPresenter = value; }
}
