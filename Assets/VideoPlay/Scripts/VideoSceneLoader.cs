using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Video;

public class VideoSceneLoader : MonoBehaviour
{
    private VideoPlayer _videoPlayer;
    [FormerlySerializedAs("UI Manager")] [SerializeField] private UIManager _uiManager;

    void Awake () 
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.loopPointReached += OnMovieFinished;
    }

    void OnMovieFinished(VideoPlayer player)
    {
        player.Stop();
        
        _uiManager.PressedNext();
    }
}
