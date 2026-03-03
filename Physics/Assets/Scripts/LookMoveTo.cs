using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LookMoveTo : MonoBehaviour
{
    public GameObject ground;
    public Transform infoBubbble;

    private Transform camera;
    private TextMeshProUGUI infoText;

    void Start()
    {
        camera = Camera.main.transform;
        if (infoBubbble != null )
        {
            infoText = GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    void Update()
    {
        Ray ray;
        RaycastHit[] hits;
        GameObject hitObject;

        Debug.DrawRay(camera.position, camera.rotation * Vector3.forward * 100.0f);

        ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        hits = Physics.RaycastAll(ray);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            hitObject = hit.collider.gameObject;
            if (hitObject == ground)
            {
                if (infoBubbble != null)
                {
                    infoText.text = "X: " + hit.point.x.ToString("F2") + ", Z: " + hit.point.z.ToString("F2");
                    infoBubbble.LookAt(camera.position);
                    infoBubbble.Rotate(0, 180f, 0);
                }
                transform.position = hit.point;
            }
        }
    }
}
