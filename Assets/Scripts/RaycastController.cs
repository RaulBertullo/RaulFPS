using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastController : MonoBehaviour
{
    private Ray ray;

    RaycastHit infoHit;

    PlayerInput input;

    [SerializeField] private Camera myCamera;

    void Awake()
    {
        myCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        input = GetComponentInParent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        //ray.origin = transform.position;
        //ray.direction = transform.TransformDirection(Vector3.right);

        Vector2 mousePosition = input.actions["MousePosition"].ReadValue<Vector2>();
        ray = myCamera.ScreenPointToRay(mousePosition);

        float raycastLength = 3f;

        Debug.DrawRay(ray.origin, ray.direction * raycastLength, Color.yellow);

        if(Physics.Raycast(ray, out infoHit, raycastLength))
        {
           
            infoHit.collider.SendMessage("ActivateObject", true, SendMessageOptions.DontRequireReceiver);
        }
    }
}
