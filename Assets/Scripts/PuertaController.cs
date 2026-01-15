using UnityEngine;

public class PuertaController : MonoBehaviour
{
    public Animator doorAnimator; // arrastras el Animator de la puerta

    // Este método lo llamas desde el SimonController
    public void OpenDoor()
    {
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Open"); // dispara la animación
        }
    }
}