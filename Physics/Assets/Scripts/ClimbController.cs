using UnityEngine;

public class ClimbController : MonoBehaviour
{
    [SerializeField] GameObject xrRig;

    private int grabCount;
    private Rigidbody rigidBody;
    private float groundLevel;

    void Start()
    {
    if (xrRig == null)
        {
            xrRig = GameObject.Find("XR Rig");
        }
    grabCount = 0;
    rigidBody = xrRig.GetComponent<Rigidbody>();
    groundLevel = xrRig.transform.position.y;
    }

    public void Grab()
    {
        grabCount++;
        rigidBody.isKinematic = true;
    }

    public void Pull(Vector3 distance)
    {
        xrRig.transform.Translate(distance);
    }

    public void Release()
    {
        grabCount--;
        if (grabCount == 0)
        {
            rigidBody.isKinematic = false;
        }
    }

    void Update()
    {
        if (xrRig.transform.position.y <= groundLevel)
        {
            Vector3 pos = xrRig.transform.position;
            pos.y = groundLevel;
            xrRig.transform.position = pos;
            rigidBody.isKinematic = true;
        }
    }
}
