using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance { get; private set; }
        
        [SerializeField] private float _fadeDuration = 0.5f;
        
        private CanvasGroup FadeCanvasGroup => UIRoot.Instance.FadeCanvasGroup;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            if (UIRoot.Instance == null)
                Debug.LogWarning("UIRoot.Instance is null in SceneLoader Awake.");
        }

        public void Load(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            yield return FadeCanvasGroup.DOFade(1f, _fadeDuration).WaitForCompletion();
            yield return SceneManager.LoadSceneAsync(sceneName);
            yield return FadeCanvasGroup.DOFade(0f, _fadeDuration).WaitForCompletion();
        }
    }
}