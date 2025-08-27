using TMPro;
using UnityEngine;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameComponent;
    [SerializeField] TextMeshProUGUI descriptionComponent;
    

    public void DisplayCard(Card card)
    {
        nameComponent.text = card.name;
        descriptionComponent.text = card.description;
    }


    // Efeito quando o mouse estiver emcima da carta
    public void Hovering()
    {
        Debug.Log("Hovering!");
    }


    // Quando o player clicar na carta
    public void Click()
    {
        Debug.Log("Chosen!");
    }
}
