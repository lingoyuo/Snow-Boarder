using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel; // Gán PausePanel trong Inspector
    private bool isPaused = false;

    void Start()
    {
        pausePanel.SetActive(false); // Ẩn Panel khi game bắt đầu
    }

    public void OpenPauseMenu()
    {
        isPaused = true;
        Time.timeScale = 0; // Dừng game
        pausePanel.SetActive(true); // Hiện PausePanel
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1; // Tiếp tục game
        pausePanel.SetActive(false); // Ẩn PausePanel
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Đặt lại tốc độ game trước khi load lại
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Load lại màn hiện tại
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
