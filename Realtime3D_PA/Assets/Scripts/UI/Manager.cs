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

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            HideUI();
        }
    }

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
