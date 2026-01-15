using UnityEngine;

public class PuertaController : MonoBehaviour
{
    public Animator doorAnimator; 

   
    public void OpenDoor()
    {
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Open"); 
        }
    }
}