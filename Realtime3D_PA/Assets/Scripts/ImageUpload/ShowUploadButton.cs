using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowUploadButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Animator animator;

    bool visible;


    // (PointerEventData eventData)-Zusatz genommen aus:
    //https://stackoverflow.com/questions/62711159/i-keep-getting-the-same-error-when-using-ipointerenterhandler-in-c-sharp
    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool("visible", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool("visible", false);
    }
}
