using Core.Interfaces;
using Infrastructure;
using UnityEngine;

namespace UI
{
    public class MenuUI : MonoBehaviour
    {
        [SerializeField] private StartGameButton startButton;

        private void Awake()
        {
            startButton.OnClicked += HandleStartClicked;
        }

        private void HandleStartClicked()
        {
            var gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
                gameManager.ResetGame();
            GameBootstrap.Instance.StateMachine.Enter<Infrastructure.StateMachine.GameLoopState>();
        }
    }
}
    
