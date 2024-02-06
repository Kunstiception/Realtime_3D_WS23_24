using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOptions : MonoBehaviour
{
    /// <summary>
    /// Referenz zum UI-Controller
    /// </summary>
    public UIController uIController;

    /// <summary>
    /// Ein Array der Toggles oben links, die versteckt bzw. gezeigt werden sollen
    /// </summary>
    public GameObject[] togglesUpperLeft;

    /// <summary>
    /// Referenz zum Camera-Controller
    /// </summary>
    public CameraController cameraController;

    // versteckt alle Toggles unterhalb des gedrückten Toggles
    public void HideToggles()
    {
        if (cameraController.currentIndex >= 0 && uIController.currentOpenPanelIndex > 2)
        {
                for (int i = uIController.currentOpenPanelIndex -2; i <= togglesUpperLeft.Length -1; i++)
                {
                    togglesUpperLeft[i].SetActive(false);
                }
        }   
    }

    // zeigt die Toggles wieder an
    public void ShowToggles()
    {

        uIController.HideAllPanels();

       
        for (int i = 0; i <= togglesUpperLeft.Length -1; i++)

        {
            togglesUpperLeft[i].gameObject.SetActive(true);
        }
        
    }
}
