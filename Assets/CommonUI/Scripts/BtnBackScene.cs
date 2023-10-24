using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnBackScene : Selectable, IPointerClickHandler
{
    void BackScene()
    {
        Scene nowScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(nowScene.buildIndex - 1);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        BackScene();
    }
}
