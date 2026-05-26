using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 5f;
    public float gravity = -20f;
    public float jumpHeight = 8f;
    public float rotationSpeed = 120f;

    [Header("Camaras")]
    public GameObject thirdPersonCamera;
    public GameObject cinematicCamera;

    private CharacterController controller;

    private Vector2 moveInput;

    private Vector3 velocity;

    private bool usingThirdPerson = true;
    private bool jumpPressed;

    void Awake()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        thirdPersonCamera.SetActive(true);
        cinematicCamera.SetActive(false);
    }

    // INPUT MOVIMIENTO

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    // INPUT SALTO

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            jumpPressed = true;
        }
    }

    // CAMBIO DE CAMARA

    public void OnSwitchCamera(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            usingThirdPerson = !usingThirdPerson;

            thirdPersonCamera.SetActive(usingThirdPerson);
            cinematicCamera.SetActive(!usingThirdPerson);
        }
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // ROTACION

        float rotationInput = moveInput.x;

        transform.Rotate(Vector3.up * rotationInput * rotationSpeed * Time.deltaTime);

        // MOVIMIENTO ADELANTE/ATRAS

        float forwardInput = moveInput.y;

        Vector3 moveDirection = transform.forward * forwardInput;

        // SI ESTA EN EL SUELO

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        // SALTO

        if (jumpPressed && controller.isGrounded)
        {
            velocity.y = jumpHeight;
        }

        jumpPressed = false;

        // GRAVEDAD

        velocity.y += gravity * Time.deltaTime;

        // MOVIMIENTO FINAL

        Vector3 finalMove =
            (moveDirection * speed) +
            new Vector3(0, velocity.y, 0);

        controller.Move(finalMove * Time.deltaTime);
    }
}