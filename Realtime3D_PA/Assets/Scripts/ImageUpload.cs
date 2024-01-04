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

    public RawImage image;
    string path;

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
}
