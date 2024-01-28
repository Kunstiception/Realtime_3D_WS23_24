using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /// <summary>
    /// Referenz zum Animator, welche die Kamerasteuerung �bernimmt
    /// </summary>
    public Animator animator;

    /// <summary>
    /// Men� f�r einen Index anzeigen
    /// Bereits ge�ffnetes Men� schlie�en
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
