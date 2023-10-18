using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [FormerlySerializedAs("Animation Duration")] [SerializeField]
    private float _durationAnim = 1f;

    [SerializeField] private HorizontalLayoutGroup topMenu;
    [SerializeReference] private BtnPause btnPause;
    [SerializeField] private RawImage imgBg;

    private Color tempColor;
    private void Awake()
    {
        tempColor = imgBg.color;
    }

    public void HideUI()
    {
        var rectTransform = topMenu.GetComponent<RectTransform>();
        rectTransform.DOAnchorPosY(80, _durationAnim).SetEase(Ease.Linear);

        //var imgBtn = btnPause.GetComponent<Image>();
        //imgBtn.DOFade(0, _durationAnim);

        imgBg.DOColor(new Color(1,1,1,0), 0.1f);
    }

    public void ShowUI()
    {
        var rectTransform = topMenu.GetComponent<RectTransform>();
        rectTransform.DOAnchorPosY(0, _durationAnim).SetEase(Ease.Linear);

        //var imgBtn = btnPause.GetComponent<Image>();
        //imgBtn.DOFade(1, _durationAnim);

        imgBg.DOColor(tempColor, 0.1f);
    }
}
