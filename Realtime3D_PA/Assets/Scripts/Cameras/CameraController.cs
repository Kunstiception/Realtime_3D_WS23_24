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

    public UIController uIController;


    public FrameController frameController;

    public FrameControllerStanding frameControllerStanding;

    private float frameHeight;

    private float frameHeightStanding;


    public void Start()
    {
        buttonStanding.SetBool("active", true);

        buttonHanging.SetBool("active", true);

        currentIndex = -1;
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

                uIController.togglesHanging.SetActive(true);
                uIController.togglesStanding.SetActive(false);
            }

            if (currentIndex < 0 && currentIndex > 2)
            {
                // Aktiviert den Button für hängende Rahmen
                buttonHanging.SetBool("active", true);

                // Deaktiviert den Button für hängende Rahmen
                buttonStanding.SetBool("active", false);

                uIController.togglesHanging.SetActive(false);
                uIController.togglesStanding.SetActive(true);

            }
        }
    }

    public void CameraPosition()
    {
        // Wenn Kamera auf hängenden Rahmen zeigt, nur dessen Menü anzeigen
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

        // Wenn Kamera auf stehenden Rahmen zeigt, nur dessen Menü anzeigen
        if (currentIndex >= 3 && currentIndex < 5)
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
