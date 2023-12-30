using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameController : MonoBehaviour
{
    /// <summary>
    /// Referenz zum Rahmenauswahl-Menü
    /// </summary>
    public GameObject frameSelectionUI;


    /// <summary>
    /// Liste aller verfügbaren Rahmen
    /// </summary>
    public GameObject[] availableFrames;

    /// <summary>
    /// Der zu ladende Rahmen
    /// </summary>
    private GameObject loadedFrame;

    /// <summary>
    /// Der gerade eben geladene Rahmen
    /// </summary>
    private GameObject currentLoadedFrame;
    
    /// <summary>
    /// Defiert unter welches GameObject das geladene
    /// Innenleben gehängt werden soll
    /// </summary>
    public GameObject anchorTransform;

    /// <summary>
    /// Lädt ein Innenleben aus dem Array für einen übergebenen Index    
    /// </summary>
    /// <param name="index">Welches Innenleben soll geladen werden</param>
    public void SetFrame(int index)
    {

    // Ist der übergebene Index gültig
        if(index>=0 && index <= availableFrames.Length - 1) 
        {
        // Prefab laden
            GameObject loadedFrame = Instantiate(availableFrames[index]);

    // Geladenes Prefab unter das angegebene GameObject hängen
    loadedFrame.transform.SetParent(anchorTransform.transform, false);

            // Geladenes Innenleben speichern
            currentLoadedFrame = loadedFrame;

            // TODO: Bereits ausgewählte Farbe wiederherstellen
            SetColor(currentColorIndex);
            
            // TODO: Bereits ausgewählte Farbe wiederherstellen
            SetMaterial(currentMateralIndex);

        }
    }
         
}
