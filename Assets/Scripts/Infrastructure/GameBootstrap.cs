using UnityEngine;
using Core.Interfaces;
using Infrastructure.StateMachine;

namespace Infrastructure
{
    public class GameBootstrap : MonoBehaviour
    {
        public static GameBootstrap Instance { get; private set; }
        public GameStateMachine StateMachine { get; private set; }
        
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(this);

            StateMachine = new GameStateMachine();
            StateMachine.Enter<BootstrapState>();
        }
    }
}