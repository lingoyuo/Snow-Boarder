using UnityEngine;

public class TrapDamageSender : DameSender
{
    public AudioManager audioManager;

    protected void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public override void Send(PlayerLivesController playerLivesController)
    {
        base.Send(playerLivesController);

        if (transform.parent != null)
        {
            audioManager.PlaySFX(audioManager.trap);
            Destroy(transform.parent.gameObject);
        }
    }
}
