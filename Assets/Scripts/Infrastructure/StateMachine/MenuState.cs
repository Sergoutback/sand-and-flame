using UnityEngine;
using Core.Interfaces;
using Runtime;

namespace Infrastructure.StateMachine
{
    public class MenuState : IGameState
    {
        private readonly GameStateMachine _stateMachine;

        public MenuState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            Debug.Log("Entered MenuState: Loading Menu scene...");
            SceneLoader.Instance.Load("01_Menu");
            // handle UI logic here if needed (e.g. ShowMenu)
        }

        public void Exit()
        {
            // handle UI logic here if needed (e.g. HideMenu)
        }
    }
}