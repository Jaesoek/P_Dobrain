using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CleanerMovent : MonoBehaviour
{
    private Camera _cam;
    private Vector3 _mTrashPos;

    private void Start()
    {
        _cam = Camera.main;
        _mTrashPos = new Vector3(-100f,-20000f, 0f);
        transform.position = _mTrashPos;
    }

    void Update()
    {
        if (Input.touchCount <= 0)
        {
            transform.position = _mTrashPos;
            return;
        }

        var touch = Input.GetTouch(0);
        transform.position = _cam.ScreenToWorldPoint(touch.position) + new Vector3(0,0,10);
    }
}
