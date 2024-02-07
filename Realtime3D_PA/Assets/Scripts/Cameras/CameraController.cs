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
    
    /// <summary>
    /// Referenz zum UIController
    /// </summary>
    public UIController uIController;

    /// <summary>
    /// Referenz zum FrameController für hängende Rahmen
    /// </summary>
    public FrameController frameController;

    /// <summary>
    /// Referenz zum FrameController für stehende Rahmen
    /// </summary>
    public FrameControllerStanding frameControllerStanding;

    /// <summary>
    /// Die Höhe des aktuellen hängenden Rahmen
    /// </summary>
    private float frameHeight;

    /// <summary>
    /// Die Höhe des aktuellen stehenden Rahmen
    /// </summary>
    private float frameHeightStanding;

    public HideOptions hideOptions;

    public GameObject[] togglesStanding;

    public GameObject[] togglesHanging;


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
        if (index > -1)
        {
            // Kommunikation mit dem Animator herstellen
            animator.SetInteger("CameraIndex", index);
            
            if (uIController.currentOpenPanel != null)
            {
                if (index == 0 && currentIndex == 2 | currentIndex == 3) 
                {
                    uIController.ActivatePanel(uIController.currentOpenPanelIndex);
                    uIController.currentOpenPanel.gameObject.SetActive(false);

                    uIController.togglesHanging.SetActive(true);
                    uIController.togglesStanding.SetActive(false);

                    for (int i = 0; i <= togglesStanding.Length - 1; i++)

                    {
                        togglesStanding[i].gameObject.SetActive(false);
                    }

                    for (int i = 0; i <= togglesHanging.Length - 1; i++)

                    {
                        togglesHanging[i].gameObject.SetActive(true);
                    }
                }
                if (index == 2 && currentIndex == 0 |currentIndex == 1)
                {
                    uIController.ActivatePanel(uIController.currentOpenPanelIndex);
                    uIController.currentOpenPanel.gameObject.SetActive(false);

                    uIController.togglesHanging.SetActive(false);
                    uIController.togglesStanding.SetActive(true);

                    for (int i = 0; i <= togglesStanding.Length - 1; i++)

                    {
                        togglesStanding[i].gameObject.SetActive(true);
                    }

                    for (int i = 0; i <= togglesHanging.Length - 1; i++)

                    {
                        togglesHanging[i].gameObject.SetActive(false);
                    }
                }
            }

            
            
            currentIndex = index;
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
        if (currentIndex >= 2 && currentIndex < 4)
        {
            // gefunden auf: https://discussions.unity.com/t/find-size-of-gameobject/6193/2
            frameHeightStanding = frameControllerStanding.currentLoadedFrameStanding.GetComponent<Renderer>().bounds.size.y;
            Debug.Log(frameHeightStanding);
            if (frameHeightStanding > 0.15)
            {
                SetCamera(3);

            }
            if (frameHeightStanding <= 0.15)
            {
                SetCamera(2);
            }
        }
    }
}
