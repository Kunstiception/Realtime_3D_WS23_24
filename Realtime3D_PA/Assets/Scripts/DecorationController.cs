using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationController : MonoBehaviour
{
    /// <summary>
    /// Verknüpfung zum FrameController-Skript
    /// </summary>
    public FrameController frameController;

    /// <summary>
    /// Ein Array mit den Dekorations-Prefabs
    /// </summary>
    public GameObject[] decorations;

    /// <summary>
    /// Die gerade geladene Dekoration
    /// </summary>
    public GameObject currentLoadedDecoration;

    /// <summary>
    /// Referenz zum Materialauswahl-Men�
    /// </summary>
    public GameObject decorationSelectionUI;


    public void SetDecoration(int index)
    {

        if (currentLoadedDecoration != null)
        {
            Destroy(currentLoadedDecoration);
            currentLoadedDecoration = null;
        }

        // Ist der übergebene Index gültig
        if (index >= 0 && index <= decorations.Length - 1)
        {
            // Dekoration anhand des ausgwählten Idex instanzieren
            GameObject loadedDecoration = Instantiate(decorations[index]);
            
            // Die geladene Deko wird in der neuen Variable gespeichert
            currentLoadedDecoration = loadedDecoration;

            // An dieselbe Position wie der gerade ausgewählte Rahmen setzen
            currentLoadedDecoration.transform.position = frameController.currentLoadedFrame.transform.position;
        }
    }
}
