using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IPointerClickHandler
{
    [FormerlySerializedAs("Animation Duration")] [SerializeField]
    private float _durationAnim = 0.8f;

    [SerializeField] private HorizontalLayoutGroup topMenu;
    [SerializeReference] private BtnPause btnPause;
    [SerializeField] private RawImage imgBg;

    private Color originBgColor;
    private void Awake()
    {
        originBgColor = imgBg.color;
        HideImmediate();
    }

    private void HideImmediate()
    {
        var rectTransform = topMenu.GetComponent<RectTransform>();
        rectTransform.DOAnchorPosY(80, 0f);

        var imgBtn = btnPause.GetComponent<Image>();
        imgBtn.DOFade(0, 0f);

        imgBg.DOColor(new Color(1,1,1,0), 0f);
    }

    private void HideUI()
    {
        var rectTransform = topMenu.GetComponent<RectTransform>();
        rectTransform.DOAnchorPosY(80, _durationAnim).SetEase(Ease.Linear);

        var imgBtn = btnPause.GetComponent<Image>();
        imgBtn.DOFade(0, _durationAnim);

        imgBg.DOColor(new Color(1,1,1,0), 0.1f);
    }

    public void ShowUI()
    {
        CancelInvoke(nameof(HideUI));

        var rectTransform = topMenu.GetComponent<RectTransform>();
        rectTransform.DOAnchorPosY(0, _durationAnim).SetEase(Ease.Linear);

        var imgBtn = btnPause.GetComponent<Image>();
        imgBtn.DOFade(1, _durationAnim);

        imgBg.DOColor(originBgColor, 0.1f);

        Invoke(nameof(HideUI), 3f);
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        ShowUI();
    }

    public void PressedNext()
    {
        var btnNextScene = topMenu.GetComponentInChildren<BtnNextScene>();
        btnNextScene.OnPointerClick(null);
    }
}
