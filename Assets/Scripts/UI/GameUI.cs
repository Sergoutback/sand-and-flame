using Core.Interfaces;
using Infrastructure;
using UnityEngine;

namespace UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private MenuButton menuButton;

        private void Awake()
        {
            menuButton.OnClicked += HandleBackToMenu;
        }

        private void HandleBackToMenu()
        {
            var gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
                gameManager.ResetGame();
            GameBootstrap.Instance.StateMachine.Enter<Infrastructure.StateMachine.MenuState>();
        }
    }
}
    
