using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 몬스터 정보 컨텐츠입니다.
/// </summary>
public class MonsterInfoContents : MonoBehaviour
{
    // 레벨, 체력을 나타내기 위한 텍스트입니다.
    [SerializeField]
    private Text lvText, hpText;

    // 체력의 필 어마운트를 조절합니다.
    [SerializeField]
    private Image hpImg;

    // 현재 위치를 지정하기 위해 렉트 트렌스폼을 가져옵니다.
    private RectTransform rectTs;

    private void Awake()
    {   
        rectTs = GetComponent<RectTransform>();
    }

    /// <summary>
    /// 체력을 설정합니다.
    /// </summary>
    /// <param name="hp">현재 체력</param>
    /// <param name="maxHp">최대 체력</param>
    public void setHp(int hp, int maxHp)
    {
        // 체력을 텍스트에 표시합니다.
        hpText.text = hp.ToString() + " / " + maxHp;

        // 체력을 이미지로 표현합니다.
        hpImg.fillAmount = (float) hp / maxHp;
    }

    /// <summary>
    /// 레벨을 설정합니다.
    /// </summary>
    /// <param name="lv">현재 레벨</param>
    public void setLv(int lv)
    {
        lvText.text = lv.ToString();
    }

    /// <summary>
    /// 해당 위치로 이동시킵니다.
    /// </summary>
    /// <param name="vec3">이동할 위치 값</param>
    public void Move(Vector3 vec3)
    {
        // 해당 위치로 이동합니다.
        if(rectTs)
            rectTs.position = vec3;
    }
}
