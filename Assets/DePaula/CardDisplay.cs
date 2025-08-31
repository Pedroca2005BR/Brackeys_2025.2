using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameComponent;
    [SerializeField] TextMeshProUGUI descriptionComponent;
    [SerializeField] Image backgroundImage;
    Sprite backgroundSprite;

    Card storedCard;

    [SerializeField] private Animator animator;
    [SerializeField] CardDisplay next;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    //public void DisplayCard(Card card)
    //{
    //    //ResetDefaultState();
    //    storedCard = card;
    //    //Flip();
    //    nameComponent.text = card.name;
    //    descriptionComponent.text = card.description;
    //    backgroundSprite = card.backgroundImage;
    //}




    public void Flip()
    {
        animator.SetTrigger("FlipStart");
    }

    public void PrepareCard(Card card)
    {
        ResetDefaultState();
        storedCard = card;
        nameComponent.text = card.name;
        descriptionComponent.text = card.description;
        backgroundSprite = card.backgroundImage;
        // Show back
        backgroundImage.sprite = card.backsideImage;
    }

    private void ResetDefaultState()
    {
        animator.SetTrigger("Reset");
    }

    private void CardChosen()
    {
        // TO DO: Chama o LevelUp manager pra aceitar o upgrade, desligar o pai, e retomar o tempo
       LevelUpManager.instance.InflictCardEffect(storedCard);
        Debug.Log("Inflicting solicited!");
    }




    // Efeito quando o mouse estiver emcima da carta
    public void Hovering()
    {
        //Debug.Log("Hovering!");
        animator.SetBool("IsMouseOn", true);
    }


    // Quando o player clicar na carta
    public void Click()
    {
        //Debug.Log("Chosen!");
        CardChosen();
    }

    // Efeito quando o mouse sai de cima da carta
    public void ExitMouse()
    {
        //Debug.Log("Mouse not in card!");
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
        if (next != null) next.Flip();
    }
}
