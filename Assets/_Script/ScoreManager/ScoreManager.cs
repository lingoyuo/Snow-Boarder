using System.IO;
using UnityEngine;

[System.Serializable]
public class ScoreData
{
    public int highScore;
}

public class ScoreManager : MonoBehaviour
{
    private static string filePath => Application.persistentDataPath + "/highscore.json";

    public static void SaveHighScore(int score)
    {
        ScoreData data = LoadHighScore();
        if (score > data.highScore)
        {
            data.highScore = score;
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(filePath, json);
        }
    }

    public static ScoreData LoadHighScore()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<ScoreData>(json);
        }
        return new ScoreData();
    }
}
