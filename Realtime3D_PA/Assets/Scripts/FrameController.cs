using UnityEngine;

/// <summary>
/// Steuert das Laden / Entladen der Innenleben (Inlays)
/// und stellt eine Methode zum Einf�rben der Innenleben bereit
/// </summary>
public class FrameController : MonoBehaviour
{
    /// <summary>
    /// Liste der verf�gbaren Innenleben
    /// </summary>
    public GameObject[] inlayPrefabs;

    /// <summary>
    /// Defiert unter welches GameObject das geladene
    /// Innenleben geh�ngt werden soll
    /// </summary>
    public GameObject anchorTransform;

    /// <summary>
    /// Liste mit verf�gbaren Farben
    /// </summary>
    public Color[] availableColors;

    /// <summary>
    /// Referenz zum Farbauswahl-Men�
    /// </summary>
    public GameObject colorSelectionUI;

    /// <summary>
    /// Referenz zu einem geladenen Innenleben
    /// </summary>
    private GameObject currentLoadedInlay;

    /// <summary>
    /// Aktuell ausge�hlter Farb-Index
    /// </summary>
    private int currentColorIndex = 0;


    private void Start()
    {
        // Set to inital state
        SetInlay(-1);
    }

    /// <summary>
    /// L�dt ein Innenleben aus dem Array f�r einen �bergebenen Index    
    /// </summary>
    /// <param name="index">Welches Innenleben soll geladen werden</param>
    public void SetInlay(int index)
    {
        if (currentLoadedInlay != null)
        {
            Destroy(currentLoadedInlay);
            currentLoadedInlay = null;
        }

        // Ist der �bergebene Index g�ltig
        if (index >= 0 && index <= inlayPrefabs.Length - 1)
        {
            // Prefab laden
            GameObject loadedInlay = Instantiate(inlayPrefabs[index]);

            // Geladenes Prefab unter das angegebene GameObject h�ngen
            loadedInlay.transform.SetParent(anchorTransform.transform, false);

            // Geladenes Innenleben speichern
            currentLoadedInlay = loadedInlay;

            // TODO: Bereits ausgew�hlte Farbe wiederherstellen
            SetColor(currentColorIndex);

            // Farb-Auswahl-Men� anzeigen
            colorSelectionUI.SetActive(true);
        }
        else
        {
            // Kein Innenleben geladen > Farb-Auswahl-Men� ausschalten
            colorSelectionUI.SetActive(false);
        }
    }

    /// <summary>
    /// Setzt die Farbe f�r ein geladenes Innenleben
    /// </summary>
    /// <param name="index">Index der gew�nschten Farbe</param>
    public void SetColor(int index)
    {
        // Suche nach allen Kind-Elementen die eine Renderer-Komponente besitzten
        Renderer[] renderer = currentLoadedInlay.GetComponentsInChildren<Renderer>(true);

        for (int i = 0; i < renderer.Length; i++)
        {
            // �berpr�fen ob der Renderer zu einem GameObject mit einem Tag geh�rt
            if (renderer[i].gameObject.CompareTag("ColorChange"))
            {
                renderer[i].material.SetColor("_Color", availableColors[index]);
            }
        }
        // Index der gerade ausgew�hlten Farbe merken
        currentColorIndex = index;
    }
}
