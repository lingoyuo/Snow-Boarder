using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public GameObject levelSelectionPanel;
    public Image levelImage;       // Hình ảnh level
    public TMP_Text levelText;         // Hiển thị số level
    public Button prevButton;      // Mũi tên qua trái
    public Button nextButton;      // Mũi tên qua phải
    public Button playButton;      // Nút chọn level để chơi
    public Button quitButton;

    public Sprite[] levelSprites;  // Mảng chứa ảnh của các Level
    private int currentLevel = 0;  // Chỉ mục Level hiện tại

    void Start()
    {
        UpdateLevelUI();  // Hiển thị Level ban đầu

        prevButton.onClick.AddListener(PreviousLevel);
        nextButton.onClick.AddListener(NextLevel);
        playButton.onClick.AddListener(PlayLevel);
        quitButton.onClick.AddListener(QuitGame);
    }

    void UpdateLevelUI()
    {
        // Cập nhật hình ảnh và số Level
        levelImage.sprite = levelSprites[currentLevel];
        levelText.text = "Level " + (currentLevel + 1);

        // Vô hiệu hóa nút nếu ở Level đầu hoặc cuối
        prevButton.interactable = currentLevel > 0;
        nextButton.interactable = currentLevel < levelSprites.Length - 1;
    }

    public void PreviousLevel()
    {
        if (currentLevel > 0)
        {
            currentLevel--;
            UpdateLevelUI();
        }
    }

    public void NextLevel()
    {
        if (currentLevel < levelSprites.Length - 1)
        {
            currentLevel++;
            UpdateLevelUI();
        }
    }

    public void PlayLevel()
    {
        // Load Scene theo tên level (đặt tên Scene là "Level1", "Level2", ...)
        string sceneName = "Level" + (currentLevel + 1);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        if (levelSelectionPanel != null)
        {
            levelSelectionPanel.SetActive(false);
        }
        Time.timeScale = 1;
    }
}
