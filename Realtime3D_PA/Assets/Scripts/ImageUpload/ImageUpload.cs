using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;

public class ImageUpload : MonoBehaviour
{
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
    public Vector3 framePosition;
    // Das neue Eltern-Objekt
    private GameObject newParent;
    // Refernz zum FrameController-Skript
    public FrameController frameController;
    // Das hochgeladene Bild
    public Texture userImage;

    private float userImageWidth;

    private float userImageHeight;

    private float userImageAspect;

    private Vector2 originalSize; 

    private RawImage rawNewAspect;



    // basiert auf:
    // https://www.reddit.com/r/gamedev/comments/dhw8ro/unity_c_allowing_a_player_to_import_an_image_mid/
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
            // Speichert das Png als Textur ab
            userImage = www.texture;
            // https://docs.unity3d.com/ScriptReference/Texture-width.html
            // Ermittel die Breite der Textur
            userImageWidth = userImage.width;
            // Ermittelt die Höhe der Textur
            userImageHeight = userImage.height;
            // Seitenverhältnis ermitteln mit Breite/Höhe
            userImageAspect = userImageWidth / userImageHeight;
            Debug.Log(userImageAspect);

            // https://docs.unity3d.com/530/Documentation/ScriptReference/RectTransform-sizeDelta.html
            originalSize = new Vector2(image.transform.localScale.x, image.transform.localScale.y);

            image.rectTransform.sizeDelta = new Vector2(userImageWidth, userImageHeight);
            // https://docs.unity3d.com/2018.3/Documentation/ScriptReference/UI.AspectRatioFitter-aspectRatio.html
            image.GetComponent<AspectRatioFitter>().aspectRatio = userImageAspect;
            Debug.Log(image.GetComponent<AspectRatioFitter>().aspectRatio);
            
            image.rectTransform.sizeDelta = new Vector2(originalSize.x, originalSize.y);
            

            //image.rectTransform.SizeToParent;

        }
    }



    // https://docs.unity3d.com/ScriptReference/Transform.SetParent.html
    public void SetNewParent()
    {
        // Der Rahmen ist der gerade aktive Rahmen
        frame = frameController.currentLoadedFrame;
        //
        newParent = frameController.currentLoadedFrame;
        // Sets "newParent" as the new parent of the child GameObject.
        parent = newParent;
        // Diese Variable enthält die Position des gerade aktiven Rahmens
        framePosition = frame.transform.position;
        // Das Kindobjekt wird an die Position des Rahmens gesetzt
        child.transform.position = framePosition;
    }
}
