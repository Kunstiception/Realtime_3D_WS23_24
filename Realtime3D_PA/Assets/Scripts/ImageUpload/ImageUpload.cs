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

    // Der Dateipfad des Pngs
    string path;

    // Unser Rahmen
    private GameObject frame;

    // Die Position unseres Rahmens
    public Vector3 framePosition;

    // Refernz zum FrameController-Skript
    public FrameController frameController;

    // Das hochgeladene Bild
    public Texture userImage;

    // Die Breite des hochegeladenen Bildes
    private float userImageWidth;

    // Die Höhe des hochegeladenen Bildes
    private float userImageHeight;

    // Das daraus resultierende Seitenverhältnis
    private float userImageAspect;



    // basiert auf:
    // https://www.reddit.com/r/gamedev/comments/dhw8ro/unity_c_allowing_a_player_to_import_an_image_mid/
    private void Awake()
    {
        // RawImage ermitteln
        image = GetComponentInChildren<RawImage>();
    }

    public void OpenExplorer()
    {
        // Hochgeladenes Bild holen
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
            // Bild speichern
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

            // Das Seitenverhätlnis des hochgeladenen Bildes auf das RawImage anwenden (scheint wirkungslos zu sein, wirkliche Anpassung geschieht durch die Einstellungen im Komponenten-Menü)
            // https://docs.unity3d.com/2018.3/Documentation/ScriptReference/UI.AspectRatioFitter-aspectRatio.html
            image.GetComponent<AspectRatioFitter>().aspectRatio = userImageAspect;
            Debug.Log(image.GetComponent<AspectRatioFitter>().aspectRatio);  
            
        }
    }
}
