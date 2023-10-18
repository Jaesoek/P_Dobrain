using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class BtnPause : Selectable, IPointerClickHandler
{
    public VideoPlayer tVideoPlayer;
    public UIManager test;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Test Click");
        
        if (tVideoPlayer.isPaused)
        {
            tVideoPlayer.Play();
            test.HideUI();
        }
        else
        {
            tVideoPlayer.Pause();
            test.ShowUI();
        }
    }
}
