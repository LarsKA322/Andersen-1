using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    private void Start()
    {
       //Removes cursor from playscreen
       // Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        //Mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //clamping rotation in y mouse, as to not look behind the player, but either directly up or directly down. 
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Y-axis rotation of player character
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //X-axis rotation of player character
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
