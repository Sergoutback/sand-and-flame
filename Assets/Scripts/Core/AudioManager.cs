using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Audio Clips")]
    [SerializeField] private AudioClip cardFlipSound;
    [SerializeField] private AudioClip cardMatchSound;
    [SerializeField] private AudioClip cardMismatchSound;
    [SerializeField] private AudioClip gameEndSound;
    [SerializeField] private AudioClip newHighscoreSound;

    [Header("Audio Settings")]
    [SerializeField] private float volume = 1f;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    public void PlayCardFlip()
    {
        if (cardFlipSound != null)
            audioSource.PlayOneShot(cardFlipSound, volume);
    }

    public void PlayCardMatch()
    {
        if (cardMatchSound != null)
            audioSource.PlayOneShot(cardMatchSound, volume);
    }

    public void PlayCardMismatch()
    {
        if (cardMismatchSound != null)
            audioSource.PlayOneShot(cardMismatchSound, volume);
    }

    public void PlayGameEnd()
    {
        if (gameEndSound != null)
            audioSource.PlayOneShot(gameEndSound, volume);
    }

    public void PlayNewHighscore()
    {
        if (newHighscoreSound != null)
            audioSource.PlayOneShot(newHighscoreSound, volume);
    }
} 