using TMPro;
using UnityEngine;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameComponent;
    [SerializeField] TextMeshProUGUI descriptionComponent;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void DisplayCard(Card card)
    {
        ResetDefaultState();
        Flip();
        nameComponent.text = card.name;
        descriptionComponent.text = card.description;
    }




    public void Flip()
    {
        animator.SetTrigger("FlipStart");
    }

    private void ResetDefaultState()
    {
        animator.SetTrigger("Reset");
    }


    // Efeito quando o mouse estiver emcima da carta
    public void Hovering()
    {
        Debug.Log("Hovering!");
        animator.SetBool("IsMouseOn", true);
    }


    // Quando o player clicar na carta
    public void Click()
    {
        Debug.Log("Chosen!");
    }

    // Efeito quando o mouse sai de cima da carta
    public void ExitMouse()
    {
        Debug.Log("Mouse not in card!");
        animator.SetBool("IsMouseOn", false);
    }

    // Efeito quando a carta termina seu giro
    public void FlipEnded()
    {

    }
}
