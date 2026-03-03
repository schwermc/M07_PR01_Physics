using UnityEngine;
using UnityEngine.UI;

public class ForceToggle : MonoBehaviour
{
    private Toggle toggle;

    void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    public void Toggle()
    {
        toggle.isOn = !toggle.isOn;
    }
}
