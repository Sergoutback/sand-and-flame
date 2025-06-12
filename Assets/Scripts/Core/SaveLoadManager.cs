using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameProgressData
{
    public int moves;
    public int matches;
    public List<int> matchedCardIds;
}

public class SaveLoadManager : MonoBehaviour
{
    private const string SaveKey = "GameProgress";

    public void Save(int moves, int matches, List<int> matchedCardIds)
    {
        GameProgressData data = new GameProgressData
        {
            moves = moves,
            matches = matches,
            matchedCardIds = matchedCardIds
        };
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(SaveKey, json);
        PlayerPrefs.Save();
    }

    public GameProgressData Load()
    {
        if (PlayerPrefs.HasKey(SaveKey))
        {
            string json = PlayerPrefs.GetString(SaveKey);
            return JsonUtility.FromJson<GameProgressData>(json);
        }
        return null;
    }
    
    public int LoadHighscore()
    {
        return PlayerPrefs.GetInt("Highscore", 0);
    }

    public void SaveHighscore(int value)
    {
        PlayerPrefs.SetInt("Highscore", value);
        PlayerPrefs.Save();
    }

    public void Clear()
    {
        PlayerPrefs.DeleteKey(SaveKey);
    }

#if UNITY_EDITOR
    [ContextMenu("Clear Highscore")]
    public void ClearHighscore()
    {
        PlayerPrefs.DeleteKey("Highscore");
        PlayerPrefs.Save();
        Debug.Log("Highscore reset!");
    }
#endif
} 