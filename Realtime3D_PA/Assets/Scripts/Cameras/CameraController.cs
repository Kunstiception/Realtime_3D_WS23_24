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
    
    /// <summary>
    /// Referenz zum UIController
    /// </summary>
    public UIController uIController;

    /// <summary>
    /// Referenz zum FrameController f�r h�ngende Rahmen
    /// </summary>
    public FrameController frameController;

    /// <summary>
    /// Referenz zum FrameController f�r stehende Rahmen
    /// </summary>
    public FrameControllerStanding frameControllerStanding;

    /// <summary>
    /// Die H�he des aktuellen h�ngenden Rahmen
    /// </summary>
    private float frameHeight;

    /// <summary>
    /// Die H�he des aktuellen stehenden Rahmen
    /// </summary>
    private float frameHeightStanding;


    public void Start()
    {
        buttonStanding.SetBool("active", true);

        buttonHanging.SetBool("active", true);

        currentIndex = -1;
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

            if (currentIndex >= 0 && currentIndex < 2)
            {
                // Aktiviert den Button f�r stehende Rahmen
                buttonStanding.SetBool("active", true);


                // Deaktiviert den Button f�r stehende Rahmen
                buttonHanging.SetBool("active", false);


            }

            if (currentIndex >= 2 && currentIndex < 4)
            {
                // Aktiviert den Button f�r h�ngende Rahmen
                buttonHanging.SetBool("active", true);

                // Deaktiviert den Button f�r h�ngende Rahmen
                buttonStanding.SetBool("active", false);
            }
        }
    }

    public void CameraPosition()
    {
        // Wenn Kamera auf h�ngenden Rahmen zeigt, nur dessen Men� anzeigen
        if (currentIndex >= 0 && currentIndex < 2)
        {
            // gefunden auf: https://discussions.unity.com/t/find-size-of-gameobject/6193/2
            frameHeight = frameController.currentLoadedFrame.GetComponent<Renderer>().bounds.size.y;

            if (frameHeight > 0.20)
            {

                SetCamera(1);
            }
            if (frameHeight <= 0.20)
            {
                SetCamera(0);
            }
        }

        // Wenn Kamera auf stehenden Rahmen zeigt, nur dessen Men� anzeigen
        if (currentIndex >= 2 && currentIndex < 4)
        {
            // gefunden auf: https://discussions.unity.com/t/find-size-of-gameobject/6193/2
            frameHeightStanding = frameControllerStanding.currentLoadedFrameStanding.GetComponent<Renderer>().bounds.size.y;

            if (frameHeightStanding > 0.15)
            {
                SetCamera(3);

            }
            if (frameHeightStanding <= 0.15)
            {
                SetCamera(4);
            }
        }
    }
}
