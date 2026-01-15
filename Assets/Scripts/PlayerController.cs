using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //1) Agregar una referencia como atributo de la clase
    //"Esta clase tiene un ATRIBUTO de TIPO CharacterController LLAMADO controller QUE ES PRIVADO"
    private CharacterController controller;
    //"Esta clase tiene un ATRIBUTO de TIPO PlayerInput LLAMADO input QUE ES PRIVADO"
    private PlayerInput input;

    private Vector2 inputMovement;

    [Header("Movimiento")]
    //SerielizeField nos permite exponer un campo en el editor sin hacerlo public
    [SerializeField] private float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //En el inicio, RECUPERAMOS EL COMPONENTE CharacterController
        controller = GetComponent<CharacterController>();
        //En el inicio, RECUPERAMOS EL COMPONENTE PlayerInput
        input = GetComponent<PlayerInput>();

        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {

        inputMovement = input.actions["Move"].ReadValue<Vector2>();  // (x,y) -> W,A, movido Joystick en el eje X o Y,...

        if (controller.isGrounded)
        {
            Debug.Log("Estoy en el suelo");
        }

        Vector3 movement = new Vector3(inputMovement.x, 0f, inputMovement.y);
        Vector3 worldMovement = transform.TransformDirection(movement * speed);
        controller.SimpleMove(worldMovement);

        //USAMOS el COMPONENTE controller CON SU MÉTODO SimpleMove
        //Debug.Log("Vector en el espacio local: " + (Vector3.right * speed));
        //Vector3 worldVector = transform.TransformDirection(Vector3.right * speed);
        //Debug.Log("Vector en el espacio del mundo: " + (worldVector));

        //controller.SimpleMove(worldVector);
    }
}
