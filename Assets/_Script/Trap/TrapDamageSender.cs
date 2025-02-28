using UnityEngine;

public class TrapDamageSender : DameSender
{
    public override void Send(PlayerLivesController playerLivesController)
    {
        base.Send(playerLivesController);

        if (transform.parent != null)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
