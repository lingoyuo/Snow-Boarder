using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicAdioSource;
    public AudioSource vfxAdioSource;

    public AudioClip musicClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicAdioSource.clip = musicClip;
        musicAdioSource.loop = true;
        musicAdioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySFX(AudioClip clip)
    {
        vfxAdioSource.clip = clip;
        vfxAdioSource.PlayOneShot(clip);
    }
}
