using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    /// <summary>
    /// Referenz um Sreenspace-Canvas
    /// </summary>
    public Canvas canvas;

    /// <summary>
    /// Boolsche Variable zum Ein- und Ausschalten des Canvas
    /// </summary>
    private bool canvasActive = true;


    // Wird die Leertaste gedrückt, wird das UI ausgeblendet
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            HideUI();
        }
    }

    // Setzt das UI aktiv oder inaktiv je nach Variable
    private void HideUI()
    {
        if (canvasActive == true)
        {
            canvas.gameObject.SetActive(false);
            canvasActive = false;    
        }

        else
        {
            canvas.gameObject.SetActive(true);
            canvasActive = true;
        }
    }
}
