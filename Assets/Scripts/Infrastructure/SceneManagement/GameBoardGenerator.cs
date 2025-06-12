using UnityEngine;
using System.Collections.Generic;

public class GameBoardGenerator : MonoBehaviour
{
    [SerializeField] private CardCollection cardCollection;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform boardParent;

    [SerializeField] private int rows = 4;
    [SerializeField] private int columns = 4;

    public System.Action OnBoardGenerated;

    void Start()
    {
        GenerateBoard();
    }

    public void GenerateBoard()
    {
        int totalCards = rows * columns;
        if (totalCards % 2 != 0)
        {
            Debug.LogError("The number of cards on the field must be even!");
            return;
        }

        int uniqueNeeded = totalCards / 2;
        List<CardData> source = new List<CardData>(cardCollection.cards);

        Shuffle(source);
        if (source.Count < uniqueNeeded)
        {
            Debug.LogError("There are not enough unique cards in the collection to fill the field!");
            return;
        }
        source = source.GetRange(0, uniqueNeeded);

        // Duplicate pairs
        List<CardData> cards = new List<CardData>(source);
        cards.AddRange(source);

        Shuffle(cards);

        for (int i = 0; i < totalCards; i++)
        {
            var cardGO = Instantiate(cardPrefab, boardParent);
            var card = cardGO.GetComponent<Card>();
            card.Initialize(cards[i]);
        }
        OnBoardGenerated?.Invoke();
    }

    private void Shuffle(List<CardData> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rnd = Random.Range(i, list.Count);
            var temp = list[i];
            list[i] = list[rnd];
            list[rnd] = temp;
        }
    }
}