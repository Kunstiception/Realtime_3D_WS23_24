using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorControllerStanding : MonoBehaviour
{
    /// <summary>
    /// Verknüpfung zum FrameController-Skript
    /// </summary>
    public FrameControllerStanding frameControllerStanding;

    /// <summary>
    /// Aktuell ausge�hlter Farb-Index
    /// </summary>
    public int currentColorIndex = 0;

    /// <summary>
    /// Die derzeit ausgewählte Farbe
    /// </summary>
    [SerializeField]
    private Color currentColor;

    /// <summary>
    /// Das Farbauswahl-Menü
    /// </summary>
    public GameObject ColorSolectionUI;

    /// <summary>
    /// Die verfügbaren Farben
    /// </summary>
    public Color[] availableColors;

    /// <summary>
    /// Setzt die Farbe f�r ein geladenes Innenleben
    /// </summary>
    /// <param name="index">Index der gew�nschten Farbe</param>
    public void SetColor(int index)
    {

        // Holt sich die Renderer-Komponente des gerade ausgewählten Rahmens
        Renderer renderer = frameControllerStanding.currentLoadedFrameStanding.GetComponent<Renderer>();

        {
            // Farbe über den Index holen
            currentColor = availableColors[index];

            // Ging mit .SetColor und dem _Color Identifier nicht, so irgendwie schon
            renderer.material.color = currentColor;
        }

        // Index der gerade ausgew�hlten Farbe merken
        currentColorIndex = index;

    }
}
