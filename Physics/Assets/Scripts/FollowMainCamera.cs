using TMPro;
using UnityEngine;

public class FollowMainCamera : MonoBehaviour
{
    [SerializeField] GameObject _text;
    [SerializeField] Transform mainCamera;
    
    void Start()
    {
        if (Camera.main != null)
        {
            mainCamera = Camera.main.transform;
        }
    }

    void Update()
    {
        if (mainCamera != null)
        {
            _text.transform.rotation = Quaternion.LookRotation(_text.transform.position - Camera.main.transform.position);
        }
    }
}
