using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public float sensitivity = 1f;

    // declare two floats in one line, adding a tooltip would apply to both variables
    public float verticalRotationMin, verticalRotationMax;

    public Transform followTransform;

    [Tooltip("How far away from the follow transform the camera would like to be, with no obstacles")]
    public float cameraZoomIdeal = 10f;

    private float currentHorizontalRotation, currentVerticalRotation;

    // the actual distance from the follow transform, after obstacle checks
    private float cameraZoomActual;

    // reference our two child objects
    private Transform boomTransform, cameraTransform;

    
    void Awake()
    {
        // get the first child object of this transform
        boomTransform = transform.GetChild(0);

        // get the first child of THAT transform
        cameraTransform = boomTransform.GetChild(0);

        currentHorizontalRotation = transform.localEulerAngles.y;
        currentVerticalRotation = boomTransform.localEulerAngles.x;

        cameraZoomActual = cameraZoomIdeal;

        // transform.localPosition is the position relative to the parent object
        cameraTransform.localPosition = new Vector3(0, 0, -cameraZoomActual);
    }

    
    void Update()
    {
        currentHorizontalRotation += Input.GetAxis("Mouse X") * sensitivity;
        currentVerticalRotation -= Input.GetAxis("Mouse Y") * sensitivity;

        currentVerticalRotation = Mathf.Clamp(currentVerticalRotation, verticalRotationMin, verticalRotationMax);

        // only our left/right rotation
        transform.localEulerAngles = new Vector3(0, currentHorizontalRotation);

        // our boom only rotates up/down
        boomTransform.localEulerAngles = new Vector3(currentVerticalRotation, 0);

        transform.position = followTransform.position;

        // get the direction to the camera (A to B is B - A)
        Vector3 directionToCamera = cameraTransform.position - followTransform.position;

        // .Raycast() will draw an invisible line and return true if it hits something
        // 'out' is a keyword to get more information from a function that just 'return'
        if (Physics.Raycast(followTransform.position, directionToCamera.normalized, out RaycastHit hit, cameraZoomIdeal))
        {
            // if we hit anything, we'll enter this block, and 'hit' will contain the info we need

            // set the actual zoom based on how far the ray travelled before hitting something
            cameraZoomActual = hit.distance;
        }
        else
        {
            // else we can zoom all the way out
            cameraZoomActual = cameraZoomIdeal;
        }

        cameraTransform.localPosition = new Vector3(0, 0, -cameraZoomActual);
    }
}
