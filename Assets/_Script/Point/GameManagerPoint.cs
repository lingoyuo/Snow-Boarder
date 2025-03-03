using UnityEngine;

public class GameManagerPoint : MonoBehaviour
{
    public static GameManagerPoint Instance { get; private set; }
    [SerializeField] public int PlayerScore { get; set; }
    [SerializeField] public int StartScore { get; set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetStartScore(int score)
    {
        StartScore = score;
    }

}
