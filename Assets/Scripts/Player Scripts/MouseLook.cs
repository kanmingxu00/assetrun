using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float mouseX;
    float mouseY;

    public static float sensitivity = 100f;
    public Transform player;
    float pitch = 0f;

    public float minAngle = -90f;
    public float maxAngle = 90f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        player = transform.parent.transform;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minAngle, maxAngle);
        transform.localRotation = Quaternion.Euler(pitch, 0, 0);
        player.Rotate(Vector3.up * mouseX);
    }
}
