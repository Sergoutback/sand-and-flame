using UnityEngine;

public class UIRoot : MonoBehaviour
{
    public static UIRoot Instance { get; private set; }
    
    [field: SerializeField] public CanvasGroup FadeCanvasGroup { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}