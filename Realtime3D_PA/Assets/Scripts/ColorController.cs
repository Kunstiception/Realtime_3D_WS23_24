using UnityEngine;

public class ColorController : MonoBehaviour
{
    /// <summary>
    /// Gerade geladener Rahmen
    /// </summary>
    private GameObject currentLoadedFrame;

    /// <summary>
    /// Mesh Renderer dessen Farbe getauscht werden soll
    /// </summary>
    public Renderer materialRenderer;

    /// <summary>
    /// Liste aller verf�gbaren Farben
    /// </summary>
    public Color[] availableColors;

    /// <summary>
    /// Referenz zum Farbauswahl-Menü
    /// </summary>
    public GameObject colorSelectionUI;

    /// <summary>
    /// Aktuell ausgeählter Farb-Index
    /// </summary>
    private int currentColorIndex = 0;

    /// <param name="index">Index der neuen Farbe</param>
    public void SetColor(int index)
    {
        // Suche nach allen Kind-Elementen die eine Renderer-Komponente besitzten
        Renderer[] renderer = currentLoadedFrame.GetComponentsInChildren<Renderer>(true);

        for (int i = 0; i < renderer.Length; i++)
        {
            // Überprüfen ob der Renderer zu einem GameObject mit einem Tag gehört
            if (renderer[i].gameObject.CompareTag("ColorChange"))
            {
                renderer[i].material.SetColor("_Color",availableColors[index]);
            }
            currentColorIndex = index;
        }
    }
}
    
