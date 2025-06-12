using UnityEngine;

[CreateAssetMenu(fileName = "CardCollection", menuName = "Cards/Card Collection")]
public class CardCollection : ScriptableObject
{
    public CardData[] cards;
}