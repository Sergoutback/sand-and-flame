using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    [SerializeField] private float cardFlipDuration = 0.5f;
    [SerializeField] private float cardMatchDelay = 1f;
    
    [Header("Events")]
    public UnityEvent<int> onMovesCountChanged;
    public UnityEvent onGameWon;

    [SerializeField] private GameBoardGenerator boardGenerator;
    
    private List<Card> cards = new List<Card>();
    private List<Card> flippedCards = new List<Card>();
    private int movesCount;
    private int matchesCount;
    private bool isProcessingMatch;
    private GameProgressUI progressUI;
    private SaveLoadManager saveLoadManager;
    private int score;
    private int highscore;
    private int comboStreak;
    
    private void Awake()
    {
        if (boardGenerator != null)
            boardGenerator.OnBoardGenerated += SubscribeToCards;
        progressUI = FindObjectOfType<GameProgressUI>();
        saveLoadManager = FindObjectOfType<SaveLoadManager>();
        highscore = saveLoadManager.LoadHighscore();
        progressUI.UpdateHighscore(highscore);
    }
    
    private void Start()
    {
        SubscribeToCards();
        LoadProgress();
    }
    
    private void OnDestroy()
    {
        if (boardGenerator != null)
            boardGenerator.OnBoardGenerated -= SubscribeToCards;

        foreach (var card in cards)
        {
            if (card != null)
                card.OnCardClicked -= HandleCardClick;
        }
    }
    
    private void SubscribeToCards()
    {
        cards = FindObjectsOfType<Card>().ToList();
        foreach (var card in cards)
        {
            card.OnCardClicked -= HandleCardClick;
            card.OnCardClicked += HandleCardClick;
            card.ShowFront();
        }
        StartCoroutine(HideAllCardsAfterDelay(3f));
    }
    
    private System.Collections.IEnumerator HideAllCardsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        foreach (var card in cards)
        {
            if (!card.IsMatched)
                card.ShowBack();
        }
    }
    
    public void HandleCardClick(Card clickedCard)
    {
        if (isProcessingMatch || flippedCards.Contains(clickedCard) || clickedCard.IsMatched)
            return;
            
        clickedCard.Flip();
        flippedCards.Add(clickedCard);
        
        if (flippedCards.Count == 2)
        {
            movesCount++;
            onMovesCountChanged?.Invoke(movesCount);
            progressUI?.UpdateTurns(movesCount);
            
            StartCoroutine(CheckForMatch());
        }
    }
    
    private System.Collections.IEnumerator CheckForMatch()
    {
        isProcessingMatch = true;
        
        // Wait for the second card to finish flipping
        yield return new WaitForSeconds(cardFlipDuration);
        
        Card firstCard = flippedCards[0];
        Card secondCard = flippedCards[1];
        
        if (firstCard.CardId == secondCard.CardId)
        {
            // Match found
            firstCard.SetMatched();
            secondCard.SetMatched();
            matchesCount++;
            progressUI?.UpdateMatches(matchesCount);
            
            AudioManager.Instance?.PlayCardMatch();
            
            yield return new WaitForSeconds(cardMatchDelay);
            firstCard.Hide();
            secondCard.Hide();
            
            SaveProgress();
            
            if (cards.All(card => card.IsMatched))
            {
                yield return new WaitForSeconds(cardMatchDelay);
                if (score > highscore)
                {
                    highscore = score;
                    saveLoadManager.SaveHighscore(highscore);
                    progressUI.UpdateHighscore(highscore);
                    AudioManager.Instance?.PlayNewHighscore();
                }
                else
                {
                    AudioManager.Instance?.PlayGameEnd();
                }
                onGameWon?.Invoke();
            }
            
            comboStreak = comboStreak > 0 ? comboStreak + 1 : 1;
            int points = (int)Mathf.Pow(2, comboStreak - 1);
            score += points;
            progressUI.UpdateScore(score);
            
            if (score > highscore)
            {
                highscore = score;
                saveLoadManager.SaveHighscore(highscore);
                progressUI.UpdateHighscore(highscore);
                AudioManager.Instance?.PlayNewHighscore();
            }
        }
        else
        {
            // No match, flip cards back
            yield return new WaitForSeconds(cardMatchDelay);
            firstCard.Flip();
            secondCard.Flip();
            comboStreak = 0;
            AudioManager.Instance?.PlayCardMismatch();
        }
        
        flippedCards.Clear();
        isProcessingMatch = false;
    }
    
    public void ResetGame()
    {
        movesCount = 0;
        matchesCount = 0;
        score = 0;
        comboStreak = 0;
        onMovesCountChanged?.Invoke(movesCount);
        progressUI?.UpdateTurns(movesCount);
        progressUI?.UpdateMatches(matchesCount);
        progressUI?.UpdateScore(score);
        flippedCards.Clear();
        isProcessingMatch = false;
        
        foreach (var card in cards)
        {
            card.Reset();
        }
        SaveProgress();
    }
    
    private void SaveProgress()
    {
        if (saveLoadManager != null)
        {
            var matchedIds = cards.Where(c => c.IsMatched).Select(c => c.CardId).ToList();
            saveLoadManager.Save(movesCount, matchesCount, matchedIds);
        }
    }
    
    private void LoadProgress()
    {
        if (saveLoadManager != null)
        {
            var data = saveLoadManager.Load();
            if (data != null)
            {
                movesCount = data.moves;
                matchesCount = data.matches;
                progressUI?.UpdateTurns(movesCount);
                progressUI?.UpdateMatches(matchesCount);
                foreach (var card in cards)
                {
                    if (data.matchedCardIds.Contains(card.CardId))
                    {
                        card.SetMatched();
                        card.Hide();
                    }
                    else
                    {
                        card.Reset();
                    }
                }
            }
        }
    }
} 