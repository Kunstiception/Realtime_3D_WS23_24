using UnityEngine;

/// <summary>
/// Tauscht das Material für ein Mesh (Mesh Renderer) 
/// aus einem Array mit verfügbaren Materialien
/// </summary>
public class MaterialController : MonoBehaviour
{
    /// <summary>
    /// Liste aller verfügbaren Materialien
    /// </summary>
    public Material[] availableMaterials;

    /// <summary>
    /// Mesh Renderer dessen Material getauscht werden soll
    /// </summary>
    public Renderer[] materialRenderer;

    /// <summary>
    /// Setzt ein Material für den MeshRenderer
    /// </summary>
    /// <param name="index">Index des neuen Material</param>
    public void SetMaterial(int index)
    {
        // Ist der Index gültig?
        if (index >= 0 && index <= availableMaterials.Length - 1)
        {
            for(int i = 0; i < materialRenderer.Length; i++)

                materialRenderer[i].material = availableMaterials[index];            
        }
    }
}
