using UnityEngine;
using Core.Interfaces;
using Runtime;


namespace Infrastructure.StateMachine
{
    public class GameLoopState : IGameState
    {
        private readonly GameStateMachine _stateMachine;

        public GameLoopState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            Debug.Log("Entered GameLoopState: Loading Game scene...");
            SceneLoader.Instance.Load("02_Game");
        }

        public void Exit() { }
    }
}