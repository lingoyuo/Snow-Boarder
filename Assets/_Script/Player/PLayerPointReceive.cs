using TMPro;
using UnityEngine;

public class PLayerPointReceive : PointReceive
{
    public static PLayerPointReceive Instance { get; private set; }
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreCompletedText;

    protected void Start()
    {
        Instance = this;
        if (GameManagerPoint.Instance != null) {
            this.point = GameManagerPoint.Instance.PlayerScore;
            GameManagerPoint.Instance.SetStartScore(this.point);
        }
            
        UpdateScoreUI();
    }

    public override void AddPoint(int point)
    {
        base.AddPoint(point);
        UpdateScoreUI();
        if (GameManagerPoint.Instance != null)
            GameManagerPoint.Instance.PlayerScore = this.point;

        //if (scoreText != null && blastTheAsteroidsText != null)
        //    WinManager.Instance.CheckWinCondition();
    }

    public void SaveScore()
    {
        ScoreManager.SaveHighScore(this.point);
    }

    public void ResetScore()
    {
        if (GameManagerPoint.Instance != null)
        {
            this.point = GameManagerPoint.Instance.StartScore; 
            GameManagerPoint.Instance.PlayerScore = this.point; 
        }
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            if (this.point <= 0) this.point = 0;

            scoreText.text = "Score: " + this.point;
        }
    }

    public void UpdateScoreCompletedUI()
    {
        SaveScore();
        if (scoreCompletedText != null)
        {
            scoreCompletedText.text = "Your score: " + this.point;
        }
    }
}
