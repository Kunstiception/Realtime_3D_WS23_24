using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameControllerStanding : MonoBehaviour
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
    /// Referenz zum DecorationController-Skript für stehende Rahmen
    /// </summary>
    public DecorationControllerStanding decorationControllerStanding;

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
    public GameObject currentLoadedFrameStanding;

    private void Start()
    {
        // Set to inital state
        SetStandingFrame(0);
        materialController.SetMaterial(0);
        colorController.SetColor(0);
    }

    /// <summary>
    /// Lädt einen Rahmen aus dem Array für einen �bergebenen Index    
    /// </summary>
    /// <param name="index">Welcher Rahmen soll geladen werden</param>
    public void SetStandingFrame(int index)
    {
        // Jetzigen ausgewählten Rahmen entsorgen
        if (currentLoadedFrameStanding != null)
        {
            Destroy(currentLoadedFrameStanding);
        }

        // Ist der übergebene Index gültig
        if (index >= 0 && index <= framePrefabs.Length - 1)
        {
            // Prefab laden
            GameObject loadedFrame = Instantiate(framePrefabs[index]);

            // Geladenes Prefab unter das angegebene GameObject hängen
            loadedFrame.transform.SetParent(anchorTransform.transform, false);

            // Geladenes Innenleben speichern
            currentLoadedFrameStanding = loadedFrame;

            // TODO: Bereits ausgew�hlte Farbe wiederherstellen
            colorController.SetColor(colorController.currentColorIndex);

            // TODO: Bereits ausgew�hlte Material wiederherstellen
            materialController.SetMaterial(materialController.currentMaterialIndex);
        }

        if (decorationControllerStanding.currentLoadedDecoration != null)
            decorationControllerStanding.SetStandingDecoration(decorationControllerStanding.currentDecorationIndex);
    }

    public void Reset()
    {
        SetStandingFrame(0);
        materialController.SetMaterial(0);
        colorController.SetColor(0);
        Destroy(decorationControllerStanding.currentLoadedDecoration);
    }


}

