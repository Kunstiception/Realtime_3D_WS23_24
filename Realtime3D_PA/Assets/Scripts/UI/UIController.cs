using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public GameObject middlePanels;


    void Start()
    {
        HideAllPanels();
    }

    
    public void Update()
    {
       
        if (cameraController.currentIndex > -1 && cameraController.currentIndex < 2)
        {
            // Aktiviert den Button für hängende Rahmen
            cameraController.buttonHanging.SetBool("active", false);

            // Deaktiviert den Button für hängende Rahmen
            cameraController.buttonStanding.SetBool("active", true);

            togglesHanging.SetActive(true);
            togglesStanding.SetActive(false);
            middlePanels.SetActive(true);
        }

        if (cameraController.currentIndex >= 2 && cameraController.currentIndex < 4)
        {
            // Aktiviert den Button für hängende Rahmen
            cameraController.buttonHanging.SetBool("active", true);

            // Deaktiviert den Button für hängende Rahmen
            cameraController.buttonStanding.SetBool("active", false);

            togglesHanging.SetActive(false);
            togglesStanding.SetActive(true);
            middlePanels.SetActive(true);
        }

        if (cameraController.currentIndex == -1)
        {
            togglesHanging.SetActive(false);
            togglesStanding.SetActive(false);
            middlePanels.SetActive(false);
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
            // Toggles unterhalb schließen
            hideOptions.HideToggles();
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
