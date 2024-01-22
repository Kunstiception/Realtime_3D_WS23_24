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

    private void Start()
    {
        // Set to inital state
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
    }

    public void Reset()
    {
        SetFrame(0);
        materialController.SetMaterial(0);
        colorController.SetColor(0);
        Destroy(decorationController.currentLoadedDecoration);
    }
        

}
