using TMPro;
using UnityEngine;

public class PLayerPointReceive : PointReceive
{
    public static PLayerPointReceive Instance { get; private set; }
    public TextMeshProUGUI scoreText;

    protected void Start()
    {
        Instance = this;
        UpdateScoreUI();
    }

    public override void AddPoint(int point)
    {
        base.AddPoint(point);
        UpdateScoreUI();

        //if (scoreText != null && blastTheAsteroidsText != null)
        //    WinManager.Instance.CheckWinCondition();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            if (this.point <= 0) this.point = 0;

            scoreText.text = "Score: " + this.point;
        }
    }
}
