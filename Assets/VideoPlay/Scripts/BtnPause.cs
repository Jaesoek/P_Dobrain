using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class BtnPause : Selectable, IPointerClickHandler
{
    public VideoPlayer tVideoPlayer;

    [SerializeField]
    private Sprite spritePause;

    [SerializeField]
    private Sprite spritePlay;

    protected override void Awake()
    {
        base.Awake();

        Image imgBtn = GetComponent<Image>();
        imgBtn.sprite = spritePause;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (tVideoPlayer.isPaused) PlayVideo();
        else PauseVideo();
        
        var parent = transform.parent.gameObject;
        parent.GetComponent<UIManager>().ShowUI();
    }

    private void PlayVideo()
    {
        tVideoPlayer.Play();
        
        Image imgBtn = GetComponent<Image>();
        imgBtn.sprite = spritePause;
    }

    private void PauseVideo()
    {
        tVideoPlayer.Pause();
        
        Image imgBtn = GetComponent<Image>();
        imgBtn.sprite = spritePlay;
    }
}
