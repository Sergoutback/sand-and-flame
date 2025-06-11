using UnityEngine;
using UnityEngine.UI;
using System;

namespace UI
{
    public class StartGameButton : MonoBehaviour
    {
        public event Action OnClicked;

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(() => OnClicked?.Invoke());
        }
    }
}