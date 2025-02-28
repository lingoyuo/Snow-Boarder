using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem snowTrail;
    public AudioManager audioManager;
    private static DustTrail instance;
    public static DustTrail Instance { get { return instance; } }

    protected void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            audioManager.PlaySFX1(audioManager.snowTrail);
            snowTrail.Play();
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            StopAudioSnowTrail();
            snowTrail.Stop();
        }
    }

    public void StopAudioSnowTrail()
    {
        audioManager.StopSFX();
    }
}
