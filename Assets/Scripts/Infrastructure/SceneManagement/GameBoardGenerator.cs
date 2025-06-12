using UnityEngine;
using System.Collections.Generic;

public class GameBoardGenerator : MonoBehaviour
{
    [SerializeField] private CardCollection cardCollection;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform boardParent;

    [SerializeField] private int rows = 4;
    [SerializeField] private int columns = 4;

    private List<CardData> _boardCards = new List<CardData>();

    void Start()
    {
        GenerateBoard();
    }

    public void GenerateBoard()
    {
        List<CardData> cards = new List<CardData>(cardCollection.cards);
        cards.AddRange(cardCollection.cards);

        Shuffle(cards);

        for (int i = 0; i < rows * columns; i++)
        {
            var cardGO = Instantiate(cardPrefab, boardParent);
            var cardView = cardGO.GetComponent<CardView>();
            cardView.SetCardData(cards[i]);
        }
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