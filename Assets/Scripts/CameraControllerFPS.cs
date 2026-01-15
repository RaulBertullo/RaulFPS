using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControllerFPS : MonoBehaviour
{
    [Header("Parámetros")]
    [SerializeField] private float sensitivity = 2f;
    [SerializeField] private float xRotation = 0f;

    PlayerInput input;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        input = GetComponentInParent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {

        //Del input, necesitamos obtener la posición del ratón.
        Vector2 mouseMovement = input.actions["Look"].ReadValue<Vector2>() * sensitivity;
        xRotation -= mouseMovement.y;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        transform.localRotation = Quaternion.Euler(xRotation, 90f, 0f);
        transform.parent.Rotate(Vector3.up * mouseMovement.x);
    }
}
