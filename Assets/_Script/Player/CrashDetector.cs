using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadSceneTimer = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !hasCrashed)
        {
            FindFirstObjectByType<PlayerMoving>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            hasCrashed = true;
            Invoke("LoadSceneLose", loadSceneTimer);
        }
    }

    void LoadSceneLose()
    {
        if (WinManager.Instance != null)
        {
            WinManager.Instance.LoseGame();
        }
    }
}
