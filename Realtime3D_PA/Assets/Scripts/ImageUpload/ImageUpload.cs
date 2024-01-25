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
    // Die Breite des hochegeladenen Bildes
    private float userImageWidth;
    // Die H�he des hochegeladenen Bildes
    private float userImageHeight;
    // Das daraus resultierende Seitenverh�ltnis
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
            // Ermittelt die H�he der Textur
            userImageHeight = userImage.height;
            // Seitenverh�ltnis ermitteln mit Breite/H�he
            userImageAspect = userImageWidth / userImageHeight;
            Debug.Log(userImageAspect);

            // Das Seitenverh�tlnis des hochgeladenen Bildes auf das RawImage anwenden (scheint wirkungslos zu sein, wirkliche Anpassung geschieht durch die Einstellungen im Komponenten-Men�)
            // https://docs.unity3d.com/2018.3/Documentation/ScriptReference/UI.AspectRatioFitter-aspectRatio.html
            image.GetComponent<AspectRatioFitter>().aspectRatio = userImageAspect;
            Debug.Log(image.GetComponent<AspectRatioFitter>().aspectRatio);  
            
        }
    }



    // https://docs.unity3d.com/ScriptReference/Transform.SetParent.html
    //public void SetNewParent()
    //{
        // Der Rahmen ist der gerade aktive Rahmen
        //frame = frameController.currentLoadedFrame;
        //
        //newParent = frameController.currentLoadedFrame;
        // Sets "newParent" as the new parent of the child GameObject.
        //parent = newParent;
        // Diese Variable enth�lt die Position des gerade aktiven Rahmens
        //framePosition = frame.transform.position;
        // Das Kindobjekt wird an die Position des Rahmens gesetzt
        //child.transform.position = framePosition;
    //}
}
