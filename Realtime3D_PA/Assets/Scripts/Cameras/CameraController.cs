using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /// <summary>
    /// Referenz zum Animator, welche die Kamerasteuerung übernimmt
    /// </summary>
    public Animator animator;

    /// <summary>
    /// Menü für einen Index anzeigen
    /// Bereits geöffnetes Menü schließen
    /// </summary>
    public void SetCamera()
    {
        if (animator == true)
        {
            // Kommunikation mit dem Animator herstellen
            animator.SetBool("Hanging", false);
        }
        

        else
        {
            animator.SetBool("Hanging", true);
        }
            
    }
    
}
