using System;
using System.Collections.Generic;
using Core.Interfaces;
using Infrastructure.StateMachine;

namespace Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IGameState> _states;
        private IGameState _activeState;

        public GameStateMachine()
        {
            _states = new Dictionary<Type, IGameState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this),
                [typeof(MenuState)] = new MenuState(this),
                [typeof(GameLoopState)] = new GameLoopState(this),
            };
        }

        public void Enter<TState>() where TState : class, IGameState
        {
            _activeState?.Exit();
            var state = GetState<TState>();
            _activeState = state;
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            _activeState?.Exit();
            var state = GetState<TState>();
            _activeState = state;
            state.Enter(payload);
        }

        private TState GetState<TState>() where TState : class, IGameState =>
            _states[typeof(TState)] as TState;
    }
}