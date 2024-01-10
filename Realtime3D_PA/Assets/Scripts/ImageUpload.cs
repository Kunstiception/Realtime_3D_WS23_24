using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;

public class ImageUpload : MonoBehaviour
{
    // basiert auf:
    // https://www.reddit.com/r/gamedev/comments/dhw8ro/unity_c_allowing_a_player_to_import_an_image_mid/
    // und:
    // https://docs.unity3d.com/ScriptReference/Transform.SetParent.html

    // Das RawImage, auf das das Png kommt
    public RawImage image;
    // Das Kind-Objekt
    public GameObject child;
    // Der Dateipfad des Pngs
    string path;
    // Das derzeitige Eltern-Objekt
    public GameObject parent;
    // Unser Rahmen
    private GameObject frame;
    // Die Position unseres Rahmens
    private Vector3 framePosition;
    // Das neue Eltern-Objekt
    private GameObject newParent;
    // Refernz zum FrameController-Skript
    public FrameController frameController;

    private void Awake()
    {
        image = GetComponentInChildren<RawImage>();
    }

    public void OpenExplorer()
    {
        path = EditorUtility.OpenFilePanel("Overwrite with png", "", "png");
        GetImage();
    }

    void GetImage()
    {
        if (path != null)
        {
            UpdateImage();
        }

        void UpdateImage()
        {
            WWW www = new WWW("file:///" + path);
            image.texture = www.texture;
        }
    }


    

    public void SetNewParent()
    {
        frame = frameController.currentLoadedFrame;
        newParent = frameController.currentLoadedFrame;
        // Sets "newParent" as the new parent of the child GameObject.
        parent = newParent;
        framePosition = frame.transform.position;
        child.transform.position = framePosition;
    }
}
