using UnityEngine;
using Core.Interfaces;
using Infrastructure.StateMachine;

namespace Infrastructure
{
    public class GameBootstrap : MonoBehaviour
    {
        public static GameBootstrap Instance { get; private set; }
        public GameStateMachine StateMachine { get; private set; }
        
        [SerializeField] private GameObject _uiRootPrefab;
        
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(this);

            // Instantiate UIRoot first
            if (_uiRootPrefab != null)
            {
                Instantiate(_uiRootPrefab);
            }
            else
            {
                Debug.LogError("UIRoot prefab is not assigned in GameBootstrap!");
            }

            StateMachine = new GameStateMachine();
            StateMachine.Enter<BootstrapState>();
        }
    }
}