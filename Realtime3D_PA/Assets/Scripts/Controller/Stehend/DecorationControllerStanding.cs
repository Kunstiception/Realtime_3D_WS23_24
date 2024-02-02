﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationControllerStanding : MonoBehaviour
{
    /// <summary>
    /// Verknüpfung zum FrameController-Skript
    /// </summary>
    public FrameControllerStanding frameControllerStanding;

    /// <summary>
    /// Ein Array mit den Dekorations-Prefabs
    /// </summary>
    public GameObject[] decorationsStanding;

    /// <summary>
    /// Die gerade geladene Dekoration
    /// </summary>
    public GameObject currentLoadedDecorationStanding;

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

    private float zOffSet;

    /// <summary>
    /// Ein Vektor zum exakten Platzieren der Dekoration
    /// </summary>
    private Vector3 offSet;

    /// <summary>
    /// Die Größe der aktuellen Dekoration
    /// </summary>
    private Vector3 decorationSize;

    //private GameObject loadedDecorationStanding;

    // Instanziert übden Index die ausgewählte Dekoration und platziert sie an der richtigen Stelle am Rahmen
    public void SetStandingDecoration(int index)
    {
        // Vorherige Dekoration entfernen
        if (currentLoadedDecorationStanding != null)
        {
            // Jetzige Dekoration entsorgen
            Destroy(currentLoadedDecorationStanding);
        }
        
        // Dekoration anhand des ausgwählten Index instanzieren
        GameObject loadedDecorationStanding = Instantiate(decorationsStanding[index]);

        // Die geladene Deko wird in der neuen Variable gespeichert
        currentLoadedDecorationStanding = loadedDecorationStanding;

        // gefunden auf: https://discussions.unity.com/t/find-size-of-gameobject/6193/2
        frameSize = frameControllerStanding.currentLoadedFrameStanding.GetComponent<Renderer>().bounds.size;
        Debug.Log("frameSize" + frameSize);

        // gefunden auf: https://discussions.unity.com/t/find-size-of-gameobject/6193/2
        decorationSize = currentLoadedDecorationStanding.GetComponent<Renderer>().bounds.size;

        


        // Ist der übergebene Index gültig
        if (index == 0)
        {


            // die Position des aktuellen Rahmens als Vektor 3
            framePosition = frameControllerStanding.currentLoadedFrameStanding.transform.position;
            Debug.Log("framePosition" + framePosition);

            //zOffSet = -framePosition.z + decorationSize.z * 13 + decorationSize.z / 6;

            // Achsenposition holen gefunden auf: https://docs.unity3d.com/ScriptReference/Vector3.html
            //An die richtige Position auf dem Rahmen setzen (in diesem Fall oben links)
            offSet = new Vector3(frameSize.x / 2 - decorationSize.x / 2, frameSize.y - decorationSize.y / 2, - frameSize.z + frameSize.z / 3 + decorationSize.z / 4);
            Debug.Log("Offset" + offSet);

            // Von der Rahmenmitte aus wird mit dem Offset die richtige Position für die Dekoration ermittelt
            currentLoadedDecorationStanding.transform.position = framePosition + offSet;

            // Seichern des aktuellen Index
            currentDecorationIndex = index;
        }

        // Ist der übergebene Index gültig
        if (index == 1)
        {


            // die Position des aktuellen Rahmens als Vektor 3
            framePosition = frameControllerStanding.currentLoadedFrameStanding.transform.position;

            // Y holen gefunden auf: https://docs.unity3d.com/ScriptReference/Vector3.html
            // An die richtige Position auf dem Rahmen setzen (in diesem Fall am Eck oben rechts)
            offSet = new Vector3(-frameSize.x / 2 + decorationSize.x / 2, frameSize.y - decorationSize.y / 2, -frameSize.z + frameSize.z / 3 + decorationSize.z / 4);

            // Von der Rahmenmitte aus wird mit dem Offset die richtige Position für die Dekoration ermittelt
            currentLoadedDecorationStanding.transform.position = framePosition + offSet;

            // Seichern des aktuellen Index
            currentDecorationIndex = index;
        }

        // Ist der übergebene Index gültig
        if (index == 2)
        {


            // die Position des aktuellen Rahmens als Vektor 3
            framePosition = frameControllerStanding.currentLoadedFrameStanding.transform.position;

            // Y holen gefunden auf: https://docs.unity3d.com/ScriptReference/Vector3.html
            // An die richtige Position auf dem Rahmen setzen (in diesem Fall am Eck unten rechts)
            offSet = new Vector3(-frameSize.x / 2 + decorationSize.x / 2, decorationSize.y / 2 , 0);

            // Von der Rahmenmitte aus wird mit dem Offset die richtige Position für die Dekoration ermittelt
            currentLoadedDecorationStanding.transform.position = framePosition + offSet;

            // Seichern des aktuellen Index
            currentDecorationIndex = index;
        }

        // Ist der übergebene Index gültig
        if (index == 3)
        {


            // die Position des aktuellen Rahmens als Vektor 3
            framePosition = frameControllerStanding.currentLoadedFrameStanding.transform.position;

            // Y holen gefunden auf: https://docs.unity3d.com/ScriptReference/Vector3.html
            //An die richtige Position auf dem Rahmen setzen (in diesem Fall unten links)
            offSet = new Vector3(frameSize.x / 2 - decorationSize.x / 2, decorationSize.y / 2, 0);

            // Von der Rahmenmitte aus wird mit dem Offset die richtige Position für die Dekoration ermittelt
            currentLoadedDecorationStanding.transform.position = framePosition + offSet;

            // Seichern des aktuellen Index
            currentDecorationIndex = index;
        }
    }
}
