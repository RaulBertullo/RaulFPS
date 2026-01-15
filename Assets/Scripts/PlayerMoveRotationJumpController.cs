using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveRotationJumpController : MonoBehaviour
{
    //1) Agregar una referencia como atributo de la clase
    //"Esta clase tiene un ATRIBUTO de TIPO CharacterController LLAMADO controller QUE ES PRIVADO"
    private CharacterController controller;
    //"Esta clase tiene un ATRIBUTO de TIPO PlayerInput LLAMADO input QUE ES PRIVADO"
    private PlayerInput input;

    private Vector2 inputMovement;
    private float verticalVelociy;

    [Header("Movimiento")]
    //SerielizeField nos permite exponer un campo en el editor sin hacerlo public
    [SerializeField] private float speed;
    [SerializeField] private float rotSpeed;

    [Header("Salto y gravedad")]
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;


    void Awake()
    {
        //En el inicio, RECUPERAMOS EL COMPONENTE CharacterController
        controller = GetComponent<CharacterController>();
        //En el inicio, RECUPERAMOS EL COMPONENTE PlayerInput
        input = GetComponent<PlayerInput>();

        speed = 5f;
        rotSpeed = 120f;
        jumpHeight = 2f;
        gravity = -9.8f;
    }


    // Update is called once per frame
    void Update()
    {
        // LEER INPUT
        ReadInput();

        // FÍSICAS (saltar, gravedad, evitar doble salto...)
        HandleGroundedAndJump();
        ApplyGravity();

        // ROTACIÓN Y MOVIMIENTO
        RotatePlayer();
        MovePlayer();
        
    }


    void ReadInput()
    {
        inputMovement = input.actions["Move"].ReadValue<Vector2>();  // (x,y) -> W,A, movido Joystick en el eje X o Y,...
    }

    void HandleGroundedAndJump()
    {
        if (controller.isGrounded)
        {
            if(verticalVelociy < 0f)
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
        //¿En qué eje rotar? (0,1,0), ¿Cuánto? léido x * velocidad de rotation * delta de tiempo
        controller.transform.Rotate(Vector3.up * rotationAxis * rotSpeed * Time.deltaTime);
    }

    void MovePlayer()
    {
        float forwardAxis = inputMovement.y;

        Vector3 localMove = new Vector3(forwardAxis, 0f, 0f);

        Vector3 worldMove = transform.TransformDirection(localMove) * speed;

        worldMove.y = verticalVelociy;

        controller.Move(worldMove * Time.deltaTime);

    }

}
