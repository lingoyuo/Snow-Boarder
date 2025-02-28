using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGameController : MonoBehaviour
{
    [SerializeField] float loadSceneTimer = 0.5f;
    [SerializeField] ParticleSystem finishEffect;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        finishEffect.Play();
        GetComponent<AudioSource>().Play();

        if (WinManager.Instance != null)
            Invoke("LoadSceneWin", loadSceneTimer);
        
    }

    void LoadSceneWin()
    {
        WinManager.Instance.CheckWinCondition();
    }
}
