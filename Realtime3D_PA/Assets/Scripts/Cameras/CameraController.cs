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
    /// Der gerade gewählte Index
    /// </summary>
    public int currentIndex;

    /// <summary>
    /// Referenz zum Animator des Buttons zur Anbringung der hängenden Rahmen
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
    /// Menü für einen Index anzeigen
    /// Bereits geöffnetes Menü schließen
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
                // Aktiviert den Button für stehende Rahmen
                buttonStanding.SetBool("active", true);
                
                // Deaktiviert den Button für stehende Rahmen
                buttonHanging.SetBool("active", false);

                
            }

            if (currentIndex < 0 && currentIndex > 2)
            {
                // Aktiviert den Button für hängende Rahmen
                buttonHanging.SetBool("active", true);

                // Deaktiviert den Button für hängende Rahmen
                buttonStanding.SetBool("active", false);

               
            }
        }
    }
}
