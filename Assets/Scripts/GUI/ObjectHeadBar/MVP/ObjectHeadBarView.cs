using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 오브젝트 상단에 UI를 보여주는 부분입니다.
/// </summary>
public class ObjectHeadBarView : MonoBehaviour
{
    // 현재 위치를 지정하기 위해 렉트 트렌스폼을 가져옵니다.
    private RectTransform rectTs;

    // 레벨, 체력을 나타내기 위한 텍스트입니다.
    [SerializeField]
    private Text lvText, hpText;

    // 체력의 필 어마운트와 필 아마운트 러프를 조절합니다.
    [SerializeField]
    private Image hpImg, lerpHpImg;

    // 데이터를 연결하기 위해 매개자의 인스턴스를 받습니다.
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

    // 체력 러프를 적용합니다.
    private void LerpFillAmount()
    {
        if (Mathf.Abs(lerpHpImg.fillAmount - hpImg.fillAmount) > 0.01f)
            lerpHpImg.fillAmount = Mathf.Lerp(lerpHpImg.fillAmount, hpImg.fillAmount, Time.deltaTime * 5f);
    }

    /// <summary>
    /// 이동시킵니다.
    /// </summary>
    /// <param name="vec3">이동할 위치</param>
    public void Move(Vector3 vec3)
    {
        // 해당 위치로 이동합니다.
        if (rectTs)
            rectTs.position = vec3;
    }

    /// <summary>
    /// 체력을 갱신합니다.
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
    /// 레벨을 갱신합니다.
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
