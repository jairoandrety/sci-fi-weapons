using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;

    [SerializeField] private Transform playerBody;
    [SerializeField] private CursorLockMode cursorLockMode;

    private float xRotation = 0f;
    private float mouseX = 0f;
    private float mouseY = 0f;

    void Start()
    {
        Cursor.lockState = cursorLockMode;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0,0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
