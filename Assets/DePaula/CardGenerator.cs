using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

public class CardGenerator : MonoBehaviour
{
    [SerializeField] private List<CardDisplay> displays;
    [SerializeField] private float timeBetweenFlips = 0.5f;

    [SerializeField] private List<Card> normalCards;
    [SerializeField] private List<Card> specialCards;

    

    public void DisplayCards()
    {
        if (TryGenerateCards(out Card[] cards))
        {
            for (int i = 0; i < displays.Count; i++)
            {
                displays[i].PrepareCard(cards[i]);
                // Dá flip na carta apenas quando passar um tempinho
                IEnumerator coroutine = FlipIndividualCard(displays[i], timeBetweenFlips*i);
                StartCoroutine(coroutine);
            }
        }
        else
        {
            Debug.LogError("Couldn't generate all cards! Check GenerateCard method in Card class OR number of cards in cardList!");
        }
    }

    IEnumerator FlipIndividualCard(CardDisplay display, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        display.Flip();
    }

    private bool TryGenerateCards(out Card[] cards)
    {
        ShuffleCards(normalCards);
        ShuffleCards(specialCards);

        // nesse bloco, o i serve para procurar cards que podem ser gerados. O k serve para colocar os cards no array final.
        // Se o i chegar no fim da lista, a geracao de cartas deu errado. Se o k chegar em 2, o loop termina.
        cards = new Card[3];
        int i = 0, k = 0;
        while (k < 2)
        {
            if (normalCards[i].CanBeGenerated())
            {
                cards[k] = normalCards[i];
                k++;
            }
            
            i++;
            if (i == normalCards.Count)
            {
                return false;
            }
        }

        // Aqui é a mesma coisa, mas para special cards.
        i = 0;
        while (k < 3)
        {
            if (specialCards[i].CanBeGenerated())
            {
                cards[k] = specialCards[i];
                k++;
            }

            i++;
            if (i == specialCards.Count)
            {
                return false;
            }
        }

        return true;
    }

    private void ShuffleCards(List<Card> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}
