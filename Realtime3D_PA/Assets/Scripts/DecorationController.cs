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

    private Vector3 frameSize;

    private Vector3 framePosition;

    private Vector3 decorationPosition;

    private Vector3 offSet;

    private Vector3 decorationSize;


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

            // gefunden auf: https://discussions.unity.com/t/find-size-of-gameobject/6193/2
           frameSize = frameController.currentLoadedFrame.GetComponent<Renderer>().bounds.size;

            // gefunden auf: https://discussions.unity.com/t/find-size-of-gameobject/6193/2
            decorationSize = currentLoadedDecoration.GetComponent<Renderer>().bounds.size;

            // die Position des aktuellen Rahmens als Vektor 3
            framePosition = frameController.currentLoadedFrame.transform.position;
            
            // Y holen gefunden auf: https://docs.unity3d.com/ScriptReference/Vector3.html
            offSet = new Vector3(0.0f, -frameSize.y/2 + decorationSize.y/2, frameSize.z);
            
            // An dieselbe Position wie der gerade ausgewählte Rahmen setzen
            currentLoadedDecoration.transform.position = framePosition + offSet;

            //decorationPosition = framePosition;

            


        }
    }
}
