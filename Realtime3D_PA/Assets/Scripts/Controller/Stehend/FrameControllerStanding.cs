using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameControllerStanding : MonoBehaviour
{
    /// <summary>
    /// Verknüpfung zum ColorController-Skript
    /// </summary>
    public ColorControllerStanding colorControllerStanding;

    /// <summary>
    /// Verknüpfung zum MaterialController-Skript
    /// </summary>
    public MaterialControllerStanding materialControllerStanding;

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
    /// Referenz zum gerad geladenen Rahmen
    /// </summary>
    public GameObject currentLoadedFrameStanding;

    private void Start()
    {
        // Set to inital state
        SetStandingFrame(0);
        materialControllerStanding.SetMaterial(0);
        colorControllerStanding.SetColor(0);
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
            colorControllerStanding.SetColor(colorControllerStanding.currentColorIndex);

            // TODO: Bereits ausgew�hlte Material wiederherstellen
            materialControllerStanding.SetMaterial(materialControllerStanding.currentMaterialIndex);
        }

        if (decorationControllerStanding.currentLoadedDecoration != null)
            decorationControllerStanding.SetStandingDecoration(decorationControllerStanding.currentDecorationIndex);
    }

    public void Reset()
    {
        SetStandingFrame(0);
        materialControllerStanding.SetMaterial(0);
        colorControllerStanding.SetColor(0);
        Destroy(decorationControllerStanding.currentLoadedDecoration);
    }


}

