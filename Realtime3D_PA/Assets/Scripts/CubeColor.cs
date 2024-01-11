using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColor : MonoBehaviour
{
    public GameObject cube;
    public GameObject ColorSolectionUI;
    [SerializeField]
    private Color currentColor;
    public Color[] availableColors;
    /// <summary>
    /// Aktuell ausge�hlter Farb-Index
    /// </summary>
    private int currentColorIndex = 0;

    /// <summary>
    /// Setzt die Farbe f�r ein geladenes Innenleben
    /// </summary>
    /// <param name="index">Index der gew�nschten Farbe</param>
    public void SetColor(int index)
    {
        
            // Suche nach allen Kind-Elementen die eine Renderer-Komponente besitzten
            Renderer renderer = cube.GetComponent<Renderer>();

            {
                currentColor = availableColors[index];
                renderer.material.color = currentColor;
            }

            // Index der gerade ausgew�hlten Farbe merken
            currentColorIndex = index;
   
    }

}
