using UnityEngine;

/// <summary>
/// Steuert das Laden / Entladen der Innenleben (Inlays)
/// und stellt eine Methode zum Einf�rben der Innenleben bereit
/// </summary>
public class FrameController : MonoBehaviour
{
    /// <summary>
    /// Verknüpfung zum ColorController-Skript
    /// </summary>
    public ColorController colorController;
    
    /// <summary>
    /// Verknüpfung zum MaterialController-Skript
    /// </summary>
    public MaterialController materialController;

    /// <summary>
    /// Referenz zum DecorationController-Skript
    /// </summary>
    public DecorationController decorationController;
    
    /// <summary>
    /// Liste der verf�gbaren Innenleben
    /// </summary>
    public GameObject[] framePrefabs;

    /// <summary>
    /// Defiert unter welches GameObject das geladene
    /// Innenleben geh�ngt werden soll
    /// </summary>
    public GameObject anchorTransform;

    /// <summary>
    /// Referenz zum Rahmenauswahl-Men�
    /// </summary>
    public GameObject frameSelectionUI;

    /// <summary>
    /// Referenz zu einem geladenen Innenleben
    /// </summary>
    public GameObject currentLoadedFrame;

    /// <summary>
    /// Der derzeitige Index
    /// </summary>
    private int currentIndex;

    private void Start()
    {
        // Anfangszustand definieren
        SetFrame(0);
        materialController.SetMaterial(0);
        colorController.SetColor(0);
    }

    /// <summary>
    /// Lädt einen Rahmen aus dem Array für einen �bergebenen Index    
    /// </summary>
    /// <param name="index">Welcher Rahmen soll geladen werden</param>
    public void SetFrame(int index)
    {
        // Jetzigen ausgewählten Rahmen entsorgen
        if (currentLoadedFrame != null)
        {
            Destroy(currentLoadedFrame);
        }

        // Ist der übergebene Index gültig
        if (index >= 0 && index <= framePrefabs.Length - 1)
        {
            // derzeitigen Index merken
            currentIndex = index;

            // Prefab laden
            GameObject loadedFrame = Instantiate(framePrefabs[index]);

            // Geladenes Prefab unter das angegebene GameObject hängen
            loadedFrame.transform.SetParent(anchorTransform.transform, false);

            // Geladenes Innenleben speichern
            currentLoadedFrame = loadedFrame;

            // TODO: Bereits ausgew�hlte Farbe wiederherstellen
            colorController.SetColor(colorController.currentColorIndex);

            // TODO: Bereits ausgew�hlte Material wiederherstellen
            materialController.SetMaterial(materialController.currentMaterialIndex);
        }

        // Ausgweählte Deko neu setzen, damit diese auch beim Rahmenwechsel erhalten bleibt
        if (decorationController.currentLoadedDecoration != null)
        decorationController.SetDecoration(decorationController.currentDecorationIndex);
    }

    // setzt alle Einstellungen am Rahmen zurück
    public void Reset()
    {
        SetFrame(currentIndex);
        materialController.SetMaterial(0);
        colorController.SetColor(0);
        Destroy(decorationController.currentLoadedDecoration);
    }
        

}
