using UnityEngine;

public class AssignCanvasEventCamera : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    void Start()
    {
        if (canvas == null)
        {
            canvas = GetComponent<Canvas>();
        }

        if (canvas && canvas.worldCamera == null)
        {
            canvas.worldCamera = Camera.main;
        }
    }
}
