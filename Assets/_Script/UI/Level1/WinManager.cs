using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject winPanel;
    public GameObject losePanel;
    public static WinManager Instance { get; private set; }

    protected void Start()
    {
        Instance = this;
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    public void CheckWinCondition()
    {
        if (DustTrail.Instance != null)
            DustTrail.Instance.StopAudioSnowTrail();
        WinGame();
    }

    public void CheckLoseCondition()
    {
        if (PlayerLivesController.Instance.currentLive <= 0)
        {
            if (DustTrail.Instance != null)
                DustTrail.Instance.StopAudioSnowTrail();
            LoseGame();
        }
    }

    private void WinGame()
    {
        if (GameTimer.Instance != null)
            GameTimer.Instance.StopTimer();
        if (PLayerPointReceive.Instance != null)
            PLayerPointReceive.Instance.UpdateScoreCompletedUI();
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoseGame()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
