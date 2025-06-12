using Core.Interfaces;
using Infrastructure;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class MenuUI : MonoBehaviour
    {
        [SerializeField] private Button easyButton;
        [SerializeField] private Button midButton;
        [SerializeField] private Button hardButton;
        [SerializeField] private StartGameButton startButton;

        private void Awake()
        {
            easyButton.onClick.AddListener(() => SelectLevel(2, 2));
            midButton.onClick.AddListener(() => SelectLevel(3, 4));
            hardButton.onClick.AddListener(() => SelectLevel(4, 4));
            startButton.OnClicked += HandleStartClicked;
        }
        private void HandleStartClicked()
        {
            var gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
                gameManager.ResetGame();
            GameBootstrap.Instance.StateMachine.Enter<Infrastructure.StateMachine.GameLoopState>();
        }
        private void SelectLevel(int rows, int columns)
        {
            if (GameSettings.Instance != null)
                GameSettings.Instance.SetGridSize(rows, columns);
            else
                Debug.LogError("GameSettings.Instance is null! Add GameSettings to the scene.");
        }
        
        private void OnLevelButtonClicked(Button selectedButton, int rows, int columns)
        {
            if (GameSettings.Instance != null)
                GameSettings.Instance.SetGridSize(rows, columns);

            // Set the selected button as Selected
            EventSystem.current.SetSelectedGameObject(selectedButton.gameObject);
        }
    }
}
    
