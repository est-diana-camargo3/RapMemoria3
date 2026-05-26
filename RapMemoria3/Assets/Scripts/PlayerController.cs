using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 5f;
    public float gravity = -9.81f;

    [Header("Camaras")]
    public GameObject thirdPersonCamera;
    public GameObject cinematicCamera;

    private CharacterController controller;

    private Vector2 moveInput;

    private Vector3 velocity;

    private bool usingThirdPerson = true;

    void Awake()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Cámara inicial
        thirdPersonCamera.SetActive(true);
        cinematicCamera.SetActive(false);
    }

    // INPUT MOVIMIENTO

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
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
        Move();
        ApplyGravity();
    }

    // MOVIMIENTO

    void Move()
    {
        // ROTACIÓN
        float rotationInput = moveInput.x;

        transform.Rotate(Vector3.up * rotationInput * 120f * Time.deltaTime);

        // MOVIMIENTO ADELANTE/ATRÁS
        float forwardInput = moveInput.y;

        Vector3 moveDirection = transform.forward * forwardInput;

        controller.Move(moveDirection * speed * Time.deltaTime);
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
