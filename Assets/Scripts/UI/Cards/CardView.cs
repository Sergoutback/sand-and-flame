// Assets/Scripts/Cards/CardView.cs
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] private Image frontImage;
    [SerializeField] private GameObject frontSide;
    [SerializeField] private GameObject backSide;

    private CardData cardData;
    private bool isFlipped = false;

    public void SetCardData(CardData data)
    {
        cardData = data;
        frontImage.sprite = cardData.cardSprite;
        ShowBack();
    }

    public void OnCardClicked()
    {
        if (!isFlipped)
            ShowFront();
        else
            ShowBack();
    }

    public void ShowFront()
    {
        frontSide.SetActive(true);
        backSide.SetActive(false);
        isFlipped = true;
    }

    public void ShowBack()
    {
        frontSide.SetActive(false);
        backSide.SetActive(true);
        isFlipped = false;
    }

    public int GetCardId() => cardData.cardId;
}