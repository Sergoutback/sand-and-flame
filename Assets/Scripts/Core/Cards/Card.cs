using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Card : MonoBehaviour
{
    public event Action<Card> OnCardClicked;
    
    [SerializeField] private CardView cardView;
    
    private bool isMatched;
    private bool isFlipped;
    
    public int CardId { get; private set; }
    public bool IsMatched => isMatched;
    public bool IsFlipped => isFlipped;
    
    private void Awake()
    {
        if (cardView == null)
        {
            cardView = GetComponent<CardView>();
        }
    }
    
    public void Initialize(CardData data)
    {
        CardId = data.cardId;
        cardView.SetCardData(data);
    }
    
    public void Flip()
    {
        isFlipped = !isFlipped;
        cardView.OnCardClicked();
    }
    
    public void SetMatched()
    {
        isMatched = true;
    }
    
    public void Reset()
    {
        isMatched = false;
        isFlipped = false;
        cardView.ShowBack();
    }
    
    public void OnClick()
    {
        OnCardClicked?.Invoke(this);
    }
    
    public void ShowFront()
    {
        cardView.ShowFront();
        isFlipped = true;
    }
    
    public void ShowBack()
    {
        cardView.ShowBack();
        isFlipped = false;
    }
    
    public void Hide()
    {
        if (cardView != null)
        {
            cardView.HideSides();
        }
    }
} 