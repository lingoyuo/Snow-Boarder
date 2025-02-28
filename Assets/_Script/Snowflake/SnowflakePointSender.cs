using UnityEngine;

public class SnowflakePointSender : PointSender
{
    public AudioManager audioManager;

    protected void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public override void Send(PointReceive pointReceive)
    {
        base.Send(pointReceive);

        if (transform.parent != null)
        {
            audioManager.PlaySFX(audioManager.point);
            Destroy(transform.parent.gameObject); 
        }
    }
}
