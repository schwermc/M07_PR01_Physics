using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GuideLocomotion : LocomotionProvider
{
    [SerializeField] Transform rigRoot;
    [SerializeField] Transform trackedTransform; // camera or controller, null  for thumbstick
    [SerializeField] float velocity = 2f;
    [SerializeField] float rotationSpeed = 100f; // degrees per second

    private bool isMoving;

    void Start()
    {
        if (rigRoot == null)
        {
            rigRoot = transform;
        }
    }


    void Update()
    {
        if(!isMoving && !CanBeginLocomotion())
            return;

        float forward = Input.GetAxis("XRI_Right_Primary2DAxis_Vertical");
        float sideways = Input.GetAxis("XRI_Right_Primary2DAxis_Horizontal");

        if (forward == 0f && sideways == 0f)
        {
            isMoving = false;
            EndLocomotion();
            return;
        }

        if (!isMoving)
        {
            isMoving = true;
            BeginLocomotion();
        }

        if (forward != 0f)
        {
            Vector3 moveDirection = Vector3.forward;
            if (trackedTransform != null)
            {
                moveDirection = trackedTransform.forward;
                moveDirection.y = 0f;
            }
            moveDirection *= -forward * velocity * Time.deltaTime;
            rigRoot.Translate(moveDirection);
        }

        if (trackedTransform == null && sideways != 0f)
        {
            float rotation = sideways * rotationSpeed * Time.deltaTime;
            rigRoot.Rotate(0, rotation, 0);
        }
    }
}
