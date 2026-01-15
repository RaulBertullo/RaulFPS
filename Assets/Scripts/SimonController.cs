using UnityEngine;
using System.Collections.Generic;

public class SimonController : MonoBehaviour
{
    public PuertaController door;

    private string[] correctSequence = { "RED", "BLUE", "GREEN", "BLUE" };
    private List<string> playerSequence = new List<string>();

    // Solo para el botón
    public bool SequenceComplete = false;

    public bool PressButton(string color)
    {
        playerSequence.Add(color);

        // Comprobamos si falla
        for (int i = 0; i < playerSequence.Count; i++)
        {
            if (playerSequence[i] != correctSequence[i])
            {
                playerSequence.Clear();
                SequenceComplete = false;
                return false; // fallo
            }
        }

        // Secuencia completada
        if (playerSequence.Count == correctSequence.Length)
        {
            door.OpenDoor();
            playerSequence.Clear();
            SequenceComplete = true;
        }
        else
        {
            SequenceComplete = false;
        }

        return true; // botón correcto hasta ahora
    }
}

