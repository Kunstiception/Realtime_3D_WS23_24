﻿using UnityEngine;

/// <summary>
/// Steuert die Anzeige der einzelnen Menüs zum Konfigurieren
/// </summary>
public class UIController : MonoBehaviour
{
    /// <summary>
    /// Liste aller Menüs
    /// </summary>
    public UIPanel[] panels;

    /// <summary>
    /// Referenz zum CameraController-Skript
    /// </summary>
    public CameraController cameraController;

    /// <summary>
    /// Die Toggles für hangende Rahmen
    /// </summary>
    public GameObject togglesHanging;

    /// <summary>
    /// Die Toggles für stehende Rahmen
    /// </summary>
    public GameObject togglesStanding;

    /// <summary>
    /// Welches Menü wird gerade angezeigt
    /// </summary>
    public UIPanel currentOpenPanel;

    /// <summary>
    /// Der derzeitige Index
    /// </summary>
    public int currentOpenPanelIndex;

    /// <summary>
    /// Referenz zum Animator
    /// </summary>
    private Animator animator;

    /// <summary>
    /// Die gerade aktive Canvas Group
    /// </summary>
    private CanvasGroup currentCanvasGroup;

    /// <summary>
    /// Referenz zum Hide Options-Skript
    /// </summary>
    public HideOptions hideOptions;

    public DecorationController decorationController;

    public FrameControllerStanding frameControllerStanding;

    private void Start()
    {
        HideAllPanels();

    }

    private void Update()
    {
        // Wenn Kamera auf hängenden Rahmen zeigt, nur dessen Menü anzeigen
        if (cameraController.currentIndex >= 0 && cameraController.currentIndex < 2)
        {
            togglesHanging.SetActive(true);
            togglesStanding.SetActive(false);

            if (decorationController.frameSize.y > 0.20)
            {
                cameraController.SetCamera(1);
                Debug.Log(decorationController.frameSize.y);
            }
        }

        // Wenn Kamera auf stehenden Rahmen zeigt, nur dessen Menü anzeigen
        else if (cameraController.currentIndex == 1 | cameraController.currentIndex == 2)
        {
            togglesStanding.SetActive(true);
            togglesHanging.SetActive(false);
        }

        // Durch erneuten Klick auf einen Toggle das Panel erst abschalten, nachdem die Animation durchlaufen wurde, also das Panel nicht mehr interactable ist
        if (currentCanvasGroup != null)
        {
            if (currentCanvasGroup.interactable = false)
            {

                currentOpenPanel.gameObject.SetActive(false);

                currentCanvasGroup = null;
            }

        }
    }
    /// <summary>
    /// Menü für einen Index anzeigen
    /// Bereits geöffnetes Menü schließen
    /// </summary>
    /// <param name="index"></param>
    public void ActivatePanel(int index)
    {
        // Bereits geöffnetes Panel schließen
        if (currentOpenPanel != null)
        {
            if (index == currentOpenPanelIndex)
            {
                currentOpenPanel.Hide();
                currentOpenPanel = null;
                hideOptions.ShowToggles();
            }
        }




        else if (index >= 0 && index <= panels.Length - 1)
        {

            currentOpenPanel = panels[index];
            // Gerade ausgewähltes Panel aktiv schalten
            currentOpenPanel.gameObject.SetActive(true);
            // Und auch zeigen
            currentOpenPanel.Show();
            // Den derzeitigen Index speichern
            currentOpenPanelIndex = index;
            hideOptions.HideToggles();
        }

        // CanvasGroup des aktuellen Panels speichern
        if (currentOpenPanel != null)
        {
            currentCanvasGroup = currentOpenPanel.GetComponent<CanvasGroup>();
        }
    }

    /// <summary>
    /// Hide all panels (e.g. on start of the application)
    /// </summary>
    public void HideAllPanels()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            // Inaktivschaltung aller Panels
            panels[i].gameObject.SetActive(false);
        }
    }
}
