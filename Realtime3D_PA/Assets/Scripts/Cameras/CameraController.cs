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
    /// Der gerade gew�hlte Index
    /// </summary>
    public int currentIndex;

    /// <summary>
    /// Referenz zum Animator des Buttons zur Anbringung der h�ngenden Rahmen
    /// </summary>
    public Animator buttonHanging;

    /// <summary>
    /// Referenz zum Animator des Buttons zur Anbringung der stehenden Rahmen
    /// </summary>
    public Animator buttonStanding;

    
    void Start()
    {
        buttonStanding.SetBool("active", true);

        buttonHanging.SetBool("active", true);
    }
    
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

            if (currentIndex >= 0 && currentIndex > 2)
            {
                // Aktiviert den Button f�r stehende Rahmen
                buttonStanding.SetBool("active", true);
                
                // Deaktiviert den Button f�r stehende Rahmen
                buttonHanging.SetBool("active", false);

                
            }

            if (currentIndex < 0 && currentIndex > 2)
            {
                // Aktiviert den Button f�r h�ngende Rahmen
                buttonHanging.SetBool("active", true);

                // Deaktiviert den Button f�r h�ngende Rahmen
                buttonStanding.SetBool("active", false);

               
            }
        }
    }
}
