using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.Video;

public class VideoSceneLoader : MonoBehaviour
{
    private VideoPlayer _videoPlayer;

    [FormerlySerializedAs("Next scene name")] [SerializeField] private string _nextSceneName;

    void Awake () 
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.loopPointReached += OnMovieFinished;
    }

    void OnMovieFinished(VideoPlayer player)
    {
        player.Stop();
        SceneManager.LoadScene(_nextSceneName);
    }
}
