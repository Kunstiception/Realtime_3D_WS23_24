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

    public GameObject togglesHanging;

    public GameObject togglesStanding;

    /// <summary>
    /// Welches Menü wird gerade angezeigt
    /// </summary>
    private UIPanel currentOpenPanel;

    private void Start()
    {
        HideAllPanels();
    }

    private void Update()
    {

        if (cameraController.currentIndex == 0)
        {
            panels[6].gameObject.SetActive(false);
            panels[7].gameObject.SetActive(false);
            panels[8].gameObject.SetActive(false);

            togglesHanging.SetActive(true);
            togglesStanding.SetActive(false);
        }

        else if (cameraController.currentIndex == 1)
        {
            panels[3].gameObject.SetActive(false);
            panels[4].gameObject.SetActive(false);
            panels[5].gameObject.SetActive(false);

            togglesStanding.SetActive(true);
            togglesHanging.SetActive(false);
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
            currentOpenPanel.gameObject.SetActive(false);
            currentOpenPanel = null;
        }

        if(index>=0 && index <=panels.Length - 1) 
        {
            currentOpenPanel = panels[index];
            // Gerade ausgewähltes Panel aktiv schalten
            currentOpenPanel.gameObject.SetActive(true);
            // Und auch zeigen
            currentOpenPanel.Show();
        }
    }

    /// <summary>
    /// Hide all panels (e.g. on start of the application)
    /// </summary>
    private void HideAllPanels() 
    {
        for (int i = 0; i < panels.Length; i++)
        {
            // Inaktivschaltung, da sich sonst die überlappenden Toggles gegenseitig blockieren
            panels[i].gameObject.SetActive(false);
        }
    }

}
