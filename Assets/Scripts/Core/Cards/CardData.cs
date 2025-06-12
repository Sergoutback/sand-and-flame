using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Cards/New Card")]
public class CardData : ScriptableObject
{
    public string cardName;
    public Sprite cardSprite;
    public int cardId;
}