using TMPro;
using UnityEngine;

public class ScoreAchievements : MonoBehaviour
{
    public TextMeshProUGUI scoreAchievements;

    private void Start()
    {
        UpdateScoreAchievementsUI();
    }

    private void UpdateScoreAchievementsUI()
    {
        if (scoreAchievements != null)
        {
            ScoreData data = ScoreManager.LoadHighScore();
            scoreAchievements.text = "Your Achievement: " + data.highScore;
        }
    }
}
