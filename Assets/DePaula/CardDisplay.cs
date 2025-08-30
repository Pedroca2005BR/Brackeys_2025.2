using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameComponent;
    [SerializeField] TextMeshProUGUI descriptionComponent;
    [SerializeField] Image backgroundImage;
    Sprite backgroundSprite;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void DisplayCard(Card card)
    {
        //ResetDefaultState();
        Flip();
        nameComponent.text = card.name;
        descriptionComponent.text = card.description;
        backgroundSprite = card.backgroundImage;
    }




    public void Flip()
    {
        animator.SetTrigger("FlipStart");
    }

    public void ResetDefaultState()
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

    // Efeito quando a carta está no meio do giro e mostra sua frente
    public void ShowFront()
    {
        backgroundImage.sprite = backgroundSprite;
    }
}
