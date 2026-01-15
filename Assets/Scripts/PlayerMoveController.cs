using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveController : MonoBehaviour
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
    [SerializeField] private float gravity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //En el inicio, RECUPERAMOS EL COMPONENTE CharacterController
        controller = GetComponent<CharacterController>();
        //En el inicio, RECUPERAMOS EL COMPONENTE PlayerInput
        input = GetComponent<PlayerInput>();

        speed = 10f;

        gravity = -9.8f;
    }

    // Update is called once per frame
    void Update()
    {

        //Obtenemos el vector 2 leído del input (a través de la action "Move")
        inputMovement = input.actions["Move"].ReadValue<Vector2>();  // (x,y) -> W,A, movido Joystick en el eje X o Y,...

        //Mapeamos de 2D a 3D con la siguiente correspondencia: x -> x, y -> z
        Vector3 motion = new Vector3(inputMovement.x, 0f, inputMovement.y);

        //Aplicamos la gravedad
        motion.y = gravity * Time.deltaTime;

        //Pasamos a coordenadas del mundo para mover al objeto con respecto a su eje de coordenadas
        Vector3 worldMotion = transform.TransformDirection(motion);

        //Aplicamos la llamada a Move con el vector worldMotion del mundo, 
        // multiplicado por la speed indicada y por el delta de tiempo
        controller.Move(worldMotion * speed * Time.deltaTime);

    }
}

