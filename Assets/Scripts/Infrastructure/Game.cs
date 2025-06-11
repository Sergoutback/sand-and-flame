using UnityEngine;

namespace Infrastructure
{
    public class Game : MonoBehaviour
    {
        public static Game Instance { get; private set; }
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