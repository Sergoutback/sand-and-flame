using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance { get; private set; }

    public int Rows { get; private set; } = 4;
    public int Columns { get; private set; } = 4;

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

    public void SetGridSize(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
    }
}