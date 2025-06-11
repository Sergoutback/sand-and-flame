using UnityEngine;

namespace Infrastructure
{
    public class BootstrapState : IGameState
    {
        private readonly GameStateMachine _stateMachine;

        public BootstrapState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            Debug.Log("Entered BootstrapState");

            _stateMachine.Enter<MenuState>();
        }

        public void Exit() { }
    }
}