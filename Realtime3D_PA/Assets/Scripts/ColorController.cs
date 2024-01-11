using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    /// <summary>
    /// Verknüpfung zum FrameController-Skript
    /// </summary>
    public FrameController frameController;

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

        // Suche nach allen Kind-Elementen die eine Renderer-Komponente besitzten
        Renderer renderer = frameController.currentLoadedFrame.GetComponent<Renderer>();

        {
            currentColor = availableColors[index];

            // Ging mit .SetColor und dem _Color Identifier nicht, so irgendwie schon
            renderer.material.color = currentColor;
        }

        // Index der gerade ausgew�hlten Farbe merken
        currentColorIndex = index;

    }
}
