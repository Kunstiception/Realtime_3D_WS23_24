using UnityEngine;

/// <summary>
/// Steuert das Laden / Entladen der Innenleben (Inlays)
/// und stellt eine Methode zum Einf�rben der Innenleben bereit
/// </summary>
public class FrameController : MonoBehaviour
{
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
    /// Liste mit verf�gbaren Farben
    /// </summary>
    public Color[] availableColors;


    /// <summary>
    /// Referenz zum Rahmenauswahl-Men�
    /// </summary>
    public GameObject frameSelectionUI;


    /// <summary>
    /// Referenz zum Farbauswahl-Men�
    /// </summary>
    public GameObject colorSelectionUI;

    /// <summary>
    /// Referenz zum Materialauswahl-Men�
    /// </summary>
    public GameObject materialSelectionUI;

    /// <summary>
    /// Referenz zu einem geladenen Innenleben
    /// </summary>
    public GameObject currentLoadedFrame;

    /// <summary>
    /// Aktuell ausge�hlter Farb-Index
    /// </summary>
    private int currentColorIndex = 0;

    /// <summary>
    /// Aktuell ausgewählter Material-Index
    /// </summary>
    private int currentMaterialIndex = 0;

    private void Start()
    {
        // Set to inital state
        SetFrame(0);
        SetMaterial(0);
    }

    /// <summary>
    /// Lädt einen Rahmen aus dem Array für einen �bergebenen Index    
    /// </summary>
    /// <param name="index">Welcher Rahmen soll geladen werden</param>
    public void SetFrame(int index)
    {
        if (currentLoadedFrame != null)
        {
            Destroy(currentLoadedFrame);
            currentLoadedFrame = null;
        }

        // Ist der übergebene Index gültig
        if (index >= 0 && index <= framePrefabs.Length - 1)
        {
            // Prefab laden
            GameObject loadedFrame = Instantiate(framePrefabs[index]);

            // Geladenes Prefab unter das angegebene GameObject hängen
            loadedFrame.transform.SetParent(anchorTransform.transform, false);

            // Geladenes Innenleben speichern
            currentLoadedFrame = loadedFrame;

            // TODO: Bereits ausgew�hlte Farbe wiederherstellen
            SetColor(currentColorIndex);

            // TODO: Bereits ausgew�hlte Material wiederherstellen
            SetMaterial(currentMaterialIndex);

            //Derzeitigen Rahmen ausgeben
            Debug.Log(currentLoadedFrame.name);
        }
    }

    /// <summary>
    /// Setzt die Farbe f�r ein geladenes Innenleben
    /// </summary>
    /// <param name="index">Index der gew�nschten Farbe</param>
    public void SetColor(int index)
    {
        // Suche nach allen Kind-Elementen die eine Renderer-Komponente besitzten
        Renderer[] renderer = currentLoadedFrame.GetComponentsInChildren<Renderer>(true);

        for (int i = 0; i < renderer.Length; i++)
        {
            // �berpr�fen ob der Renderer zu einem GameObject mit einem Tag geh�rt
            if (renderer[i].gameObject.CompareTag("ColorChange"))
            {
                renderer[i].material.SetColor("_Color", availableColors[index]);
            }
        }
        // Index der gerade ausgew�hlten Farbe merken
        currentColorIndex = index;
    }


    /// <summary>
    /// Liste aller verf�gbaren Materialien
    /// </summary>
    public Material[] availableMaterials;


    /// <summary>
    /// Das Default-Material
    /// </summary>
    public Material defaultMaterial;

    /// <summary>
    /// Das derzeit angewandte Material
    /// </summary>
    private Material currentMaterial;

    /// <summary>
    /// Setzt ein Material f�r den MeshRenderer
    /// </summary>
    /// <param name="index">Index des neuen Material</param>
    public void SetMaterial(int index)
    {

        // Suche nach allen Kind-Elementen die eine Renderer-Komponente besitzten
        Renderer[] renderer = currentLoadedFrame.GetComponentsInChildren<Renderer>(true);
        
        if (currentLoadedFrame != null)
        {
            Material currentMaterial = currentLoadedFrame.GetComponent<Material>();
        }
        for (int i = 0; i < currentLoadedFrame.GetComponentsInChildren<Renderer>().Length; i++)
        {
            // �berpr�fen ob der Renderer zu einem GameObject mit einem Tag geh�rt
            if (renderer[i].gameObject.CompareTag("ColorChange"))
            {
                currentMaterial = availableMaterials[index];
            }
            else
                currentMaterial = defaultMaterial;
        }
        currentMaterialIndex = index;
        Debug.Log(currentMaterial.name);
    }
}
