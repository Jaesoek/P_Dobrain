using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class BtnNextScene : Selectable, IPointerClickHandler
{
    [FormerlySerializedAs("Next scene name")] [SerializeField] private string _nextSceneName;

    void NextLevel()
    {
        SceneManager.LoadScene(_nextSceneName);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked!");
        NextLevel();
    }
}
