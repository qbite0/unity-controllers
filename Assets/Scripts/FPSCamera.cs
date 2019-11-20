using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    [Header("Main")]
    public float Sensitivity = 3f;

    public Vector2 Rotation = Vector2.zero;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Rotation += new Vector2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X")) * Sensitivity;

        Rotation.x = ClampAngle(Rotation.x, -90f, 90f);
        Rotation.y = ClampAngle(Rotation.y, -360f, 360f);

        transform.rotation = Quaternion.Euler(-Rotation.x, Rotation.y, 0);
    }

    public float ClampAngle(float angle, float min, float max)
    {
        angle = angle % 360;
        if ((angle >= -360F) && (angle <= 360F))
        {
            if (angle < -360F) angle += 360F;
            if (angle > 360F) angle -= 360F;
        }
        return Mathf.Clamp(angle, min, max);
    }
}
