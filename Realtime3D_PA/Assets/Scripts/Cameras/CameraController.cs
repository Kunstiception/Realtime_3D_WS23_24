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
    private int currentIndex;

    public Animator buttonHanging;

    public Animator buttonStanding;

    
    void Start()
    {
        buttonStanding.SetBool("active", true);

        buttonHanging.SetBool("active", false);
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

            if (currentIndex == 0)
            {
                buttonStanding.SetBool("active", true);

                buttonHanging.SetBool("active", false);
            }

            else
            {
                buttonHanging.SetBool("active", true);

                buttonStanding.SetBool("active", false);
            }
        }
    }
}
