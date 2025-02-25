using System.Collections.Generic;
using UnityEngine;

public class PlayerLivesController : MonoBehaviour
{
    public static PlayerLivesController Instance { get; private set; }
    public int maxLive = 3;
    public int currentLive = 0;

    public GameObject heartPrefab;
    public RectTransform heartsContainer;

    private List<GameObject> heartIcons = new List<GameObject>();

    protected void Start()
    {
        Instance = this;

        heartPrefab.SetActive(false);
        currentLive = maxLive;
        UpdateHeartsUI();
    }

    public void AddLive()
    {
        if (currentLive < maxLive)
        {
            currentLive++;
            UpdateHeartsUI();
        }
    }

    public void RemoveLive()
    {
        if (currentLive > 0)
        {
            currentLive--;
            UpdateHeartsUI();
            //WinManager.Instance.CheckLoseCondition();
        }
    }

    private void UpdateHeartsUI()
    {
        foreach (GameObject heart in heartIcons)
        {
            Destroy(heart);
        }
        heartIcons.Clear();

        for (int i = 0; i < currentLive; i++)
        {
            GameObject heart = Instantiate(heartPrefab, heartsContainer);
            heartIcons.Add(heart);
            heart.SetActive(true);
        }
    }
}
