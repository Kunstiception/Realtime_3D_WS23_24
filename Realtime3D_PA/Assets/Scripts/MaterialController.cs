using UnityEngine;

/// <summary>
/// Tauscht das Material für ein Mesh (Mesh Renderer) 
/// aus einem Array mit verfügbaren Materialien
/// </summary>
public class MaterialController : MonoBehaviour
{
    /// <summary>
    /// Referenz zum Materialauswahl-Menü
    /// </summary>
    public GameObject materialSelectionUI;


    /// <summary>
    /// Liste aller verfügbaren Materialien
    /// </summary>
    public Material[] availableMaterials;

    /// <summary>
    /// Mesh Renderer dessen Material getauscht werden soll
    /// </summary>
    public Renderer materialRenderer;

    /// <summary>
    /// Setzt ein Material für den MeshRenderer
    /// </summary>
    /// <param name="index">Index des neuen Material</param>
    public void SetMaterial(int index)
    {
        // Ist der Index gültig?
        if (index >= 0 && index <= availableMaterials.Length - 1)
        {
            materialRenderer.material = availableMaterials[index];            
        }
    }
}
