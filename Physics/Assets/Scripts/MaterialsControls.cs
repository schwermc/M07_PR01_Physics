using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MaterialsControls : MonoBehaviour
{
    [Header("Smoothness")]
    public Slider smoothnessSlider;
    public TextMeshProUGUI smoothnessText;
    private float _smoothness;

    [Header("Normal")]
    public Slider normalSlider;
    public TextMeshProUGUI normalText;
    private float _normal;

    [Header("Occlucion")]
    public Slider occlusionSlider;
    public TextMeshProUGUI occlusionText;
    private float _occlusion;

    [Header("List of objects")]
    public List<Renderer> renderers = new List<Renderer>();

    void Start()
    {
        smoothnessSlider.value = 1f;
        normalSlider.value = 1f;
        occlusionSlider.value = 1f;
    }

    public float Smoothness
    {
        get => _smoothness;
        set
        {
            SetFloatProperty("_Smoothness", value);
            smoothnessText.text = value.ToString("F2");
        }
    }

    public float Normal
    {
        get => _normal;
        set
        {
            SetFloatProperty("_BumpScale", value);
            normalText.text = value.ToString("F2");
        }
    }

    public float Occlusion
    {
        get => _occlusion;
        set
        {
            SetFloatProperty("_OcclusionStrength", value);
            occlusionText.text = value.ToString("F1");
        }
    }

    private void SetFloatProperty(string name, float value)
    {
        for (int i = 0; i < renderers.Count; i++)
        {
            renderers.ElementAt(i).material.SetFloat(name, value);
        }
    }
}
