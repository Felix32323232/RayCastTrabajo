using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFPSController : MonoBehaviour
{
    private CharacterController controller;
    private PlayerInput input;

    private Vector2 inputMovement;
    private float verticalVelociy;

    [Header("Movimiento")]
    [SerializeField] private float speed;
    [SerializeField] private float rotSpeed;

    [Header("Salto y gravedad")]
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;
    RaycastShooter ray;


    void Awake()
    {
        controller = GetComponent<CharacterController>();
        input = GetComponent<PlayerInput>();

        speed = 14f;
        rotSpeed = 120f;
        jumpHeight = 2f;
        gravity = -9.8f;
        ray = GetComponent<RaycastShooter>();
    }

    void Update()
    {
        Ray();
        ReadInput();

        HandleGroundedAndJump();
        ApplyGravity();

        MovePlayer();

    }
    void ReadInput()
    {
        inputMovement = input.actions["Move"].ReadValue<Vector2>();  
    }
    void Ray()
    {
        if (input.actions["Interact"].WasPerformedThisFrame())
        {
            ray.ShootRay();
        }
    }
    void HandleGroundedAndJump()
    {
        if (controller.isGrounded)
        {
            if (verticalVelociy < 0f)
            {
                verticalVelociy = -2f;
            }

            if (input.actions["Jump"].WasPerformedThisFrame())
            {
                verticalVelociy = Mathf.Sqrt(-2f * jumpHeight * gravity);
            }
        }
    }
    void ApplyGravity()
    {
        verticalVelociy += gravity * Time.deltaTime;
    }
    void RotatePlayer()
    {
        float rotationAxis = inputMovement.x;
        controller.transform.Rotate(Vector3.up * rotationAxis * rotSpeed * Time.deltaTime);
    }
    void MovePlayer()
    {
        Vector3 localMove = new Vector3(inputMovement.y, 0f, inputMovement.x);

        Vector3 worldMove = transform.TransformDirection(localMove) * speed;

        worldMove.y = verticalVelociy;

        controller.Move(worldMove * Time.deltaTime);

    }
    

}
