using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader _instance;
    public static SceneLoader Instance => _instance;

    private CanvasGroup _CanvaGroupFade;
    float _fadeDuration = 1.5f;

    private void Awake()
    {
        _CanvaGroupFade = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void ChangeScene(string sceneName)
    {
        _CanvaGroupFade.DOFade(1, _fadeDuration)
            .OnStart(() => { _CanvaGroupFade.blocksRaycasts = true; })
            .OnComplete(() => { StartCoroutine(nameof(LoadScene), sceneName); });
    }

    private IEnumerator LoadScene(string sceneName)
    {
        gameObject.SetActive(true);

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;

        while (!(async.isDone))
        {
            yield return null;

            async.allowSceneActivation = true;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _CanvaGroupFade.DOFade(0, _fadeDuration)
            .OnComplete(() => { _CanvaGroupFade.blocksRaycasts = false; });
    }
}