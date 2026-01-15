using UnityEngine;

public class SimonButton : MonoBehaviour
{
    public SimonController simon;

    public AudioSource audioSource;
    public AudioClip pressClip;       
    public AudioClip correctClip;    
    public AudioClip wrongClip;       

    public void Interact()
    {
        
        if (audioSource != null && pressClip != null)
        {
            audioSource.PlayOneShot(pressClip);
        }

       
        bool result = simon.PressButton(gameObject.name);

        
        if (result && simon.SequenceComplete)
        {
            if (correctClip != null)
                audioSource.PlayOneShot(correctClip);
        }
        else if (!result)
        {
            if (wrongClip != null)
                audioSource.PlayOneShot(wrongClip);
        }
    }
}
