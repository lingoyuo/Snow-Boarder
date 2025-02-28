using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicAdioSource;
    public AudioSource vfxAudioSource;

    public AudioClip musicClip;
    public AudioClip snowTrail;
    public AudioClip point;
    public AudioClip trap;

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
        vfxAudioSource.clip = clip;
        vfxAudioSource.PlayOneShot(clip);
    }

    public void PlaySFX1(AudioClip clip)
    {
        vfxAudioSource.clip = clip;
        vfxAudioSource.Play();
    }

    public void StopSFX()
    {
        if (vfxAudioSource != null)
        {
            vfxAudioSource.Stop();
        }
    }
}
