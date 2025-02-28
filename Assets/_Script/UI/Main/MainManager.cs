using UnityEngine;

public class MainManager : MonoBehaviour
{
    public GameObject pausePanel; // Gán PausePanel trong Inspector
    public GameObject controllPanel;
    public GameObject achievementsPanel;
    private bool isPaused = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pausePanel.SetActive(false);
        controllPanel.SetActive(false);
        achievementsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenMainMenu()
    {
        isPaused = true;
        Time.timeScale = 0; // Dừng game
        pausePanel.SetActive(true); // Hiện PausePanel
    }

    public void CloseMainMenu()
    {
        isPaused = false;
        Time.timeScale = 1; // Tiếp tục game
        pausePanel.SetActive(false); // Ẩn PausePanel
    }

    public void OpenControllMenu()
    {
        isPaused = true;
        Time.timeScale = 0;
        controllPanel.SetActive(true);
    }

    public void CloseControllMenu()
    {
        isPaused = false;
        Time.timeScale = 1;
        controllPanel.SetActive(false);
    }

    public void OpenAchievementsMenu()
    {
        isPaused = true;
        Time.timeScale = 0;
        achievementsPanel.SetActive(true);
    }

    public void CloseAchievementsMenu()
    {
        isPaused = false;
        Time.timeScale = 1;
        achievementsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
