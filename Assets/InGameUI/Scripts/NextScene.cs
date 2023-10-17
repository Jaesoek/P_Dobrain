using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(NextLevel);
    }

    void NextLevel()
    {
        Scene nowScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(nowScene.buildIndex + 1);
    }
}
