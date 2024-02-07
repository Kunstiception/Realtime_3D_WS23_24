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

    /// <summary>
    /// Referenz zum HideOptions-Skript
    /// </summary>
    public HideOptions hideOptions;

    /// <summary>
    /// Die Toggles f�r stehende Rahmen
    /// </summary>
    public GameObject[] togglesStanding;

    /// <summary>
    /// Die Toggles f�r h�ngende Rahmen
    /// </summary>
    public GameObject[] togglesHanging;

    // Aktiviert die Auswahlm�glichkeiten f�r "h�ngend" und "stehend" und setzt die initiale Kamerapositon �ber den Index
    public void Start()
    {
        buttonStanding.SetBool("active", true);

        buttonHanging.SetBool("active", true);

        currentIndex = -1;
    }

    /// <summary>
    /// Setzt den Index f�r den Animator der Kamera
    /// </summary>
    /// <param name="index">Welche Kamera angesteuert werden soll</param>
    public void SetCamera(int index)
    {
        if (index > -1)
        {
            // Kommunikation mit dem Animator herstellen
            animator.SetInteger("CameraIndex", index);
            
            // Falls derzeit ein Panel ge�ffnet ist
            if (uIController.currentOpenPanel != null)
            {
                // Falls der �bergebene Index 0 ist, und die Kamera derzeit entweder auf Position zwei oder drei steht
                if (index == 0 && currentIndex == 2 | currentIndex == 3) 
                {
                    // Panel deaktivieren
                    uIController.ActivatePanel(uIController.currentOpenPanelIndex);
                    uIController.currentOpenPanel.gameObject.SetActive(false);

                    // Togglegruppen ein- bzw. ausschalten
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
                // Falls �bergebener Index 2 ist, und die derzeitige Kameraposition 0 oder 1 ist
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

            
            // Der �bergebene Index ist die neue Kameraposition
            currentIndex = index;
        }
    }

    // Mit jedem neu instanziierten Rahmen wird berechnet, ob die Kameraposition angepasst werden muss
    public void CameraPosition()
    {
        // Wenn Kamera auf h�ngenden Rahmen zeigt, nur dessen Men� anzeigen
        if (currentIndex >= 0 && currentIndex < 2)
        {
            // gefunden auf: https://discussions.unity.com/t/find-size-of-gameobject/6193/2
            frameHeight = frameController.currentLoadedFrame.GetComponent<Renderer>().bounds.size.y;

            // Falls der Rahmen eine gewisse H�he erreicht hat: wechsele die Kamera
            if (frameHeight > 0.20)
            {
                SetCamera(1);
            }
            if (frameHeight <= 0.20)
            {
                SetCamera(0);
            }
        }

    }
}
