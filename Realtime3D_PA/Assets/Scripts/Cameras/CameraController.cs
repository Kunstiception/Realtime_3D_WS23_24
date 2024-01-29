using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /// <summary>
    /// Referenz zum Animator, welche die Kamerasteuerung �bernimmt
    /// </summary>
    public Animator animator;

    private int currentIndex;

    /// <summary>
    /// Men� f�r einen Index anzeigen
    /// Bereits ge�ffnetes Men� schlie�en
    /// </summary>
    /// <param name="index">Welche Kamera angesteuert werden soll</param>
    public void SetCamera(int index)
    {
        if (index >= 0)
        {
            // Kommunikation mit dem Animator herstellen
            animator.SetInteger("CameraIndex", index);

            currentIndex = index;
        }
    }
    
}
