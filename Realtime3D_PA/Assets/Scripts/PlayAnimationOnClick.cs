using UnityEngine;

/// <summary>
/// Parameter im Animator verändern,
/// wenn auf das Modell geklickt wird
/// </summary>
public class PlayAnimationOnClick : MonoBehaviour
{
    // Referenz zum Animator der 
    // angesteuert werden soll
    public Animator animator;

    private void OnMouseUpAsButton()
    {
        bool currentState = animator.GetBool("isOpen");
        animator.SetBool("isOpen", !currentState);
    }
}
