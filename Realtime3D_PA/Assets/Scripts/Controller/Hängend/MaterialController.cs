using UnityEngine;

/// <summary>
/// Tauscht das Material für ein Mesh (Mesh Renderer) 
/// aus einem Array mit verfügbaren Materialien
/// </summary>
public class MaterialController : MonoBehaviour
{
    /// <summary>
    /// Verknüpfung zum FrameController-Skript
    /// </summary>
    public FrameController frameController;

    /// <summary>
    /// Verknüpfung zum ColorController-Skript
    /// </summary>
    public ColorController colorController;

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

        // Suche nach Renderer-Komponente des akutuellen Rahmens
        Renderer renderer = frameController.currentLoadedFrame.GetComponent<Renderer>();
        // Das Material ist gleich dem derzeit angewählten Material
        currentMaterial = availableMaterials[index];
        // Material setzen
        renderer.material = currentMaterial;
        // Index merken
        currentMaterialIndex = index;
        
        // Gerade ausgewählte Farbe setzen
        if(colorController.currentColorIndex != null)
        {
            colorController.SetColor(colorController.currentColorIndex);
        }
        


        Debug.Log(currentMaterial.name);
    }
}
