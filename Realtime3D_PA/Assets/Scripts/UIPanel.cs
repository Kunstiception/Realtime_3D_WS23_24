using UnityEngine;

/// <summary>
/// Steuert die Sichbarkeit von Menüs durch den UIController
/// </summary>
public class UIPanel : MonoBehaviour
{
    /// <summary>
    /// Referenz zum Animator, wenn das Menü animiert werden soll
    /// </summary>
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Menü anzeigen
    /// Ist ein Animator vorhanden: Spiele Animation ab
    /// Keine Animator: Schalte das GameObject ein
    /// </summary>
    public void Show()
    {
        if (animator != null) 
        {
            animator.SetBool("visible", true);
        }
        else 
        {
            gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Menü ausschalten
    /// Ist ein Animator vorhanden: Spiele Animation ab
    /// Keine Animator: Schalte das GameObject aus
    /// </summary>
    public void Hide()
    {
        if (animator != null)
        {
            animator.SetBool("visible", false);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
