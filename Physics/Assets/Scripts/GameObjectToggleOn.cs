using UnityEngine;

public class GameObjectToggleOn : MonoBehaviour
{
    [SerializeField] bool _gameObjectToggle;
    [SerializeField] GameObject _gameObject;

    void Awake()
    {
        _gameObject = gameObject; //transform.root.gameObject;
    }

    void Start()
    {
        _gameObjectToggle = _gameObject.activeSelf;
        if (_gameObjectToggle)
        {
            _gameObjectToggle = false;
            _gameObject.SetActive(_gameObjectToggle);
        }
    }

    public void ToggleGameObject()
    {
        _gameObjectToggle = _gameObjectToggle ? false : true;
        _gameObject.SetActive(_gameObjectToggle);
    }
}
