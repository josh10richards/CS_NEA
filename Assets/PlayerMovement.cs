using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //VARIABLES
    public CharacterController controller;
    public float speed = 5f;

    private Vector2 moveInput;
    private Vector2 lookInput;

    public float mouseSensitivity = 100f;
    public Transform cameraTransform;

    private float xRotation = 0f;

    private float gravity = -9.81f;
    private Vector3 velocity;

    

    
    
    
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }


    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;

        controller.Move(move * speed * Time.deltaTime);


        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);

        if (controller.isGrounded && velocity.y<0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        
        controller.Move(velocity * Time.deltaTime);
    }
}
