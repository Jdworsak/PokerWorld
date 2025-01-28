using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f; // Movement speed
    public float mouseSensitivity = 100f; // Mouse sensitivity for looking around

    private Transform playerCamera; // Reference to the camera
    private float xRotation = 0f; // Track vertical camera rotation

    private void Start()
    {
        // Get the player camera (assumes it's a child of the player GameObject)
        playerCamera = Camera.main.transform;

        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        MovePlayer();
        LookAround();
    }

    private void MovePlayer()
    {
        // Get input from WASD or arrow keys
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Combine the input into a direction vector
        Vector3 movement = transform.right * moveHorizontal + transform.forward * moveVertical;

        // Move the player
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    private void LookAround()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the player horizontally
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera vertically (clamp to prevent over-rotation)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}

//Code by CHATGPT OpenAI. ChatGPT. Version 4, OpenAI, 2024, https://chat.openai.com.
