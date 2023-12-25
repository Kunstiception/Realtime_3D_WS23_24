using UnityEngine;

/// <summary>
/// Steuert das Laden / Entladen der Innenleben (Inlays)
/// und stellt eine Methode zum Einfärben der Innenleben bereit
/// </summary>
public class InlayController : MonoBehaviour
{
    /// <summary>
    /// Liste der verfügbaren Innenleben
    /// </summary>
    public GameObject[] inlayPrefabs;

    /// <summary>
    /// Defiert unter welches GameObject das geladene
    /// Innenleben gehängt werden soll
    /// </summary>
    public GameObject anchorTransform;

    /// <summary>
    /// Liste mit verfügbaren Farben
    /// </summary>
    public Color[] availableColors;

    /// <summary>
    /// Referenz zum Farbauswahl-Menü
    /// </summary>
    public GameObject colorSelectionUI;

    /// <summary>
    /// Referenz zu einem geladenen Innenleben
    /// </summary>
    private GameObject currentLoadedInlay;

    /// <summary>
    /// Aktuell ausgeählter Farb-Index
    /// </summary>
    private int currentColorIndex = 0;


    private void Start()
    {
        // Set to inital state
        SetInlay(-1);
    }

    /// <summary>
    /// Lädt ein Innenleben aus dem Array für einen übergebenen Index    
    /// </summary>
    /// <param name="index">Welches Innenleben soll geladen werden</param>
    public void SetInlay(int index) 
    {
        if (currentLoadedInlay != null) 
        {
            Destroy(currentLoadedInlay);
            currentLoadedInlay = null;
        }

        // Ist der übergebene Index gültig
        if(index>=0 && index <= inlayPrefabs.Length - 1) 
        {
            // Prefab laden
            GameObject loadedInlay = Instantiate(inlayPrefabs[index]);

            // Geladenes Prefab unter das angegebene GameObject hängen
            loadedInlay.transform.SetParent(anchorTransform.transform, false);

            // Geladenes Innenleben speichern
            currentLoadedInlay = loadedInlay;

            // TODO: Bereits ausgewählte Farbe wiederherstellen
            SetColor(currentColorIndex);

            // Farb-Auswahl-Menü anzeigen
            colorSelectionUI.SetActive(true);
        } else 
        {
            // Kein Innenleben geladen > Farb-Auswahl-Menü ausschalten
            colorSelectionUI.SetActive(false);
        }
    }

    /// <summary>
    /// Setzt die Farbe für ein geladenes Innenleben
    /// </summary>
    /// <param name="index">Index der gewünschten Farbe</param>
    public void SetColor(int index)
    {
        // Suche nach allen Kind-Elementen die eine Renderer-Komponente besitzten
        Renderer[] renderer = currentLoadedInlay.GetComponentsInChildren<Renderer>(true);

        for (int i = 0; i < renderer.Length; i++)
        {
            // Überprüfen ob der Renderer zu einem GameObject mit einem Tag gehört
            if (renderer[i].gameObject.CompareTag("ColorChange")) 
            {
                renderer[i].material.SetColor("_Color", availableColors[index]);
            }            
        }
        // Index der gerade ausgewählten Farbe merken
        currentColorIndex = index;
    }
}
