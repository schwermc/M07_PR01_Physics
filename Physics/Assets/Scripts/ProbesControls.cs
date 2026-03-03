using UnityEngine;
using UnityEngine.UI;

public class ProbesControls : MonoBehaviour
{
    [Header("Toggle")]
    public Toggle lightProbesToggle;
    public Toggle reflectionProbesToggle;

    [Header("Object")]
    public GameObject lightProbes;
    public GameObject reflectionProbes;

    public bool LightProbes
    {
        get => lightProbes.activeInHierarchy;
        set => lightProbes.SetActive(value);
    }

    public bool ReflectionProbes
    {
        get => reflectionProbes.activeInHierarchy;
        set => reflectionProbes.SetActive(value);
    }

    void Start()
    {
        lightProbesToggle.isOn = LightProbes;
        reflectionProbesToggle.isOn = ReflectionProbes;
    }
}
