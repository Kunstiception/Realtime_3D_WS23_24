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
    /// Referenz zum Animator, welche die Kamerasteuerung übernimmt
    /// </summary>
    //public Animator animator;

    /// <summary>
    /// Welches Menü wird gerade angezeigt
    /// </summary>
    private UIPanel currentOpenPanel;

    private void Start()
    {
        HideAllPanels();
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
            currentOpenPanel.Hide();
            currentOpenPanel = null;
        }

        if(index>=0 && index <=panels.Length - 1) 
        {
            currentOpenPanel = panels[index];
            currentOpenPanel.Show();
        }

        // Kommunikation mit dem Animator herstellen
        // animator.SetInteger("cameraIndex", index);
    }

    /// <summary>
    /// Hide all panels (e.g. on start of the application)
    /// </summary>
    private void HideAllPanels() 
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].Hide();
        }
    }

}
