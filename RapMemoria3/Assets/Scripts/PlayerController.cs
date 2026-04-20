using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 5f;
    public float gravity = -9.81f;

    [Header("Camara")]
    public Transform cameraPivot;
    public float mouseSensitivity = 100f;
    public float yRotationLimit = 80f;

    [Header("Cambio de cámara")]
    public Transform firstPersonPosition;
    public Transform thirdPersonPosition;
    private bool isFirstPerson = false;

    private CharacterController controller;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private Vector3 velocity;

    private float xRotation = 0f;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // INPUT SYSTEM

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    public void OnSwitchCamera(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isFirstPerson = !isFirstPerson;

            if (isFirstPerson)
            {
                Camera.main.transform.position = firstPersonPosition.position;
            }
            else
            {
                Camera.main.transform.position = thirdPersonPosition.position;
            }
        }
    }

    void Update()
    {
        Move();
        Look();
        ApplyGravity();
    }

    // MOVIMIENTO

    void Move()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        move = transform.TransformDirection(move);

        controller.Move(move * speed * Time.deltaTime);
    }

    // ROTACIÓN CÁMARA

    void Look()
    {
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -yRotationLimit, yRotationLimit);

        cameraPivot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
    }

    // GRAVEDAD

    void ApplyGravity()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
