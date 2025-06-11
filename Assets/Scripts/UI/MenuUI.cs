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
            Game.Instance.StateMachine.Enter<Infrastructure.GameLoopState>();
        }
    }
}
    
