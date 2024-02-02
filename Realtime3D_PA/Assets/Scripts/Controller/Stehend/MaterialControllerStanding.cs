using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialControllerStanding : MonoBehaviour
{
    /// <summary>
    /// Verknüpfung zum FrameController-Skript
    /// </summary>
    public FrameControllerStanding frameControllerStanding;

    /// <summary>
    /// Verknüpfung zum ColorController-Skript
    /// </summary>
    public ColorControllerStanding colorControllerStanding;

    /// <summary>
    /// Liste aller verfügbaren Materialien
    /// </summary>
    public Material[] availableMaterials;

    /// <summary>
    /// Referenz zum Materialauswahl-Men�
    /// </summary>
    public GameObject materialSelectionUI;

    /// <summary>
    /// Der Renderer, dessen Material geändert werden soll
    /// </summary>
    Renderer materialRenderer;

    /// <summary>
    /// Das Default-Material
    /// </summary>
    public Material defaultMaterial;

    /// <summary>
    /// Das derzeit angewandte Material
    /// </summary>
    [SerializeField]
    private Material currentMaterial;

    /// <summary>
    /// Aktuell ausgewählter Material-Index
    /// </summary>
    public int currentMaterialIndex = 0;

    private void Start()
    {
        Material currentMaterial = defaultMaterial;
    }


    /// <summary>
    /// Setzt ein Material f�r den MeshRenderer
    /// </summary>
    /// <param name="index">Index des neuen Material</param>
    public void SetMaterial(int index)
    {
        //if (index >=0 && index <= availableMaterials.Length -1)

        // Suche nach Renderer-Komponente des akutuellen Rahmens
        Renderer renderer = frameControllerStanding.currentLoadedFrameStanding.GetComponent<Renderer>();
        // Das Material ist gleich dem derzeit angewählten Material
        currentMaterial = availableMaterials[index];
        // Material setzen
        renderer.material = currentMaterial;
        // Index merken
        currentMaterialIndex = index;

        // Gerade ausgewählte Farbe setzen
        if (colorControllerStanding.currentColorIndex != null)
        {
            colorControllerStanding.SetColor(colorControllerStanding.currentColorIndex);
        }



        Debug.Log(currentMaterial.name);
    }
}
