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

    public CameraController cameraController;
    
    public void HideToggles()
    {
        if (uIController.currentOpenPanelIndex == 3 | uIController.currentOpenPanelIndex == 6)
        {
            togglesUpperLeft[1].SetActive(false);
            togglesUpperLeft[2].SetActive(false);
            togglesUpperLeft[4].SetActive(false);
            togglesUpperLeft[5].SetActive(false);
        }

        if (uIController.currentOpenPanelIndex == 4 | uIController.currentOpenPanelIndex == 7)
        {

            togglesUpperLeft[2].SetActive(false);

            togglesUpperLeft[5].SetActive(false);
        }
    }

    public void ShowToggles()
    {
        if (cameraController.currentIndex == 0)
        {
            for (int i = 1; i <= 5; i++)

            {
                togglesUpperLeft[i].gameObject.SetActive(true);
            }
        }

        if (cameraController.currentIndex == 1)
        {
            for (int i = 4; i <= 8; i++)

            {
                togglesUpperLeft[i].gameObject.SetActive(true);
            }
        }
    }
}
