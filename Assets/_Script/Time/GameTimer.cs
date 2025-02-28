using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // UI Text để hiển thị thời gian
    public TextMeshProUGUI timerCompleteText; // UI Text để hiển thị thời gian
    private float elapsedTime = 0; // Biến lưu thời gian đã trôi qua
    private bool timerIsRunning = false; // Trạng thái chạy của timer
    private static GameTimer instance = null; // Singleton
    public static GameTimer Instance { get { return instance; } }

    // Singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartTimer(); // Bắt đầu đếm thời gian
    }

    void Update()
    {
        if (timerIsRunning)
        {
            elapsedTime += Time.deltaTime; // Tăng thời gian
            DisplayTime(elapsedTime); // Hiển thị thời gian
        }
    }

    // Hiển thị thời gian ở dạng "mm:ss"
    void DisplayTime(float timeToDisplay)
    {
        // Tính phút và giây
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); // Lấy số phút
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); // Lấy số giây

        // Hiển thị định dạng mm:ss
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Hàm bắt đầu bộ đếm
    public void StartTimer()
    {
        timerIsRunning = true;
        elapsedTime = 0; // Reset thời gian về 0 khi bắt đầu
    }

    // Hàm dừng bộ đếm
    public void StopTimer()
    {
        timerIsRunning = false;
        timerCompleteText.text = "Time: " + GetElapsedTime();
    }

    // Hàm lấy thời gian hoàn thành
    public string GetElapsedTime()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60); // Chia để lấy phút
        int seconds = Mathf.FloorToInt(elapsedTime % 60); // Phần dư lấy giây

        return $"{minutes:00}:{seconds:00}"; // Format theo dạng mm:ss
    }
}
