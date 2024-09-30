using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class MouseLook : MonoBehaviour
{
    // Start is called before the first frame update
    public enum RotationAxes
    {
        MouseXandY  = 0,
        MouseY = 1,
        MouseX = 2,
    }
    public RotationAxes axes = RotationAxes.MouseXandY;
    public float sensitivityHorz = 1.0f;
    public float sensitivityVert = 1.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float verticalRotate = 0;

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHorz, 0);
        } else if (axes == RotationAxes.MouseY)
        {
            verticalRotate -= Input.GetAxis("Mouse Y") * sensitivityVert;
            verticalRotate = Mathf.Clamp(verticalRotate, minimumVert, maximumVert);

            float horizontalRotate = transform .localEulerAngles.y;

            transform.localEulerAngles = new Vector3(verticalRotate, horizontalRotate, 0);
        } else
        {
            verticalRotate -= Input.GetAxis("Mouse Y") * sensitivityVert;
            verticalRotate = Mathf.Clamp(verticalRotate, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sensitivityHorz;
            float horizontalRotate = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(verticalRotate, horizontalRotate, 0);
        }
    }
}
