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
    /// Der aktuelle Index
    /// </summary>
    public int currentDecorationIndex;

    /// <summary>
    /// Referenz zum Materialauswahl-Men�
    /// </summary>
    public GameObject decorationSelectionUI;

    /// <summary>
    /// Die Maße des gerade geladenen Rahmens
    /// </summary>
    private Vector3 frameSize;

    /// <summary>
    /// Die Position des gerade geladenen Rahmens
    /// </summary>
    private Vector3 framePosition;

    /// <summary>
    /// Die Position, an der die ausgwählte Dekoration gehängt werden soll
    /// </summary>
    private Vector3 decorationPosition;

    /// <summary>
    /// Ein Vektor zum exakten Platzieren der Dekoration
    /// </summary>
    private Vector3 offSet;

    /// <summary>
    /// Die Größe der aktuellen Dekoration
    /// </summary>
    private Vector3 decorationSize;

    public void Start()
    {
        currentLoadedDecoration = null;
    }
    
    // Instanziert übden Index die ausgewählte Dekoration und platziert sie an der richtigen Stelle am Rahmen
    public void SetDecoration(int index)
    {
        // Vorherige Dekoration entfernen
        if (currentLoadedDecoration != null)
        {
            // Jetzige Dekoration entsorgen
            Destroy(currentLoadedDecoration);   
        }

        // Dekoration anhand des ausgwählten Idex instanzieren
        GameObject loadedDecoration = Instantiate(decorations[index]);

        // Die geladene Deko wird in der neuen Variable gespeichert
        currentLoadedDecoration = loadedDecoration;

        // gefunden auf: https://discussions.unity.com/t/find-size-of-gameobject/6193/2
        frameSize = frameController.currentLoadedFrame.GetComponent<Renderer>().bounds.size;

        // gefunden auf: https://discussions.unity.com/t/find-size-of-gameobject/6193/2
        decorationSize = currentLoadedDecoration.GetComponent<Renderer>().bounds.size;

        // Ist der übergebene Index gültig
        if (index % 2 == 0)
        {


            // die Position des aktuellen Rahmens als Vektor 3
            framePosition = frameController.currentLoadedFrame.transform.position;

            // Y holen gefunden auf: https://docs.unity3d.com/ScriptReference/Vector3.html
            //An die richtige Position auf dem Rahmen setzen (in diesem Fall oben links)
            offSet = new Vector3(-frameSize.x/2 - decorationSize.x, frameSize.y / 2 - decorationSize.y / 2, frameSize.z / 2 - decorationSize.z / 2);

            // Von der Rahmenmitte aus wird mit dem Offset die richtige Position für die Dekoration ermittelt
            currentLoadedDecoration.transform.position = framePosition + offSet;

            // Seichern des aktuellen Index
            currentDecorationIndex = index;

            Debug.Log("oben links");
        }


        // Ist der übergebene Index gültig
        if (index % 2 == 1)
        {


            // die Position des aktuellen Rahmens als Vektor 3
            framePosition = frameController.currentLoadedFrame.transform.position;

            // Y holen gefunden auf: https://docs.unity3d.com/ScriptReference/Vector3.html
            // An die richtige Position auf dem Rahmen setzen (in diesem Fall am Eck unten rechts)
            offSet = new Vector3(-frameSize.x / 2 - decorationSize.x, - frameSize.y / 2 + decorationSize.y / 2, - frameSize.z / 2 + decorationSize.z / 2);

            // Von der Rahmenmitte aus wird mit dem Offset die richtige Position für die Dekoration ermittelt
            currentLoadedDecoration.transform.position = framePosition + offSet;

            // Seichern des aktuellen Index
            currentDecorationIndex = index;
            Debug.Log("unten rechts");
        }
    }
}
