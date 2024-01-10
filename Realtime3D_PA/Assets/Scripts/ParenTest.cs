using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParenTest : MonoBehaviour
{

    public GameObject child;
    public FrameController frameController;
    public GameObject parent;
    private GameObject frame;
    private Vector3 framePosition;
    private GameObject newParent;

    //Invoked when a button is clicked.
    public void Example()
    {
        frame = frameController.currentLoadedFrame;
        newParent = frameController.currentLoadedFrame;
        // Sets "newParent" as the new parent of the child GameObject.
        parent = newParent;
        framePosition = frame.transform.position;
        child.transform.position = framePosition;
    }
   
}
