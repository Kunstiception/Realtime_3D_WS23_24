using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameController : MonoBehaviour
{
    /// <summary>
    /// Referenz zum Rahmenauswahl-Men�
    /// </summary>
    public GameObject frameSelectionUI;


    /// <summary>
    /// Liste aller verf�gbaren Rahmen
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
    /// Innenleben geh�ngt werden soll
    /// </summary>
    public GameObject anchorTransform;

    /// <summary>
    /// L�dt ein Innenleben aus dem Array f�r einen �bergebenen Index    
    /// </summary>
    /// <param name="index">Welches Innenleben soll geladen werden</param>
    public void SetFrame(int index)
    {

    // Ist der �bergebene Index g�ltig
        if(index>=0 && index <= availableFrames.Length - 1) 
        {
        // Prefab laden
            GameObject loadedFrame = Instantiate(availableFrames[index]);

    // Geladenes Prefab unter das angegebene GameObject h�ngen
    loadedFrame.transform.SetParent(anchorTransform.transform, false);

            // Geladenes Innenleben speichern
            currentLoadedFrame = loadedFrame;

            // TODO: Bereits ausgew�hlte Farbe wiederherstellen
            SetColor(currentColorIndex);
            
            // TODO: Bereits ausgew�hlte Farbe wiederherstellen
            SetMaterial(currentMateralIndex);

        }
    }
         
}
