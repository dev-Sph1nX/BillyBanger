using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float sensibility;
    public Transform orientation;
    
    [Range(0, 90)]
    public int cameraXLimit;


    float xRotation;
    float yRotation;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensibility;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensibility;

        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -cameraXLimit, cameraXLimit);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

}
