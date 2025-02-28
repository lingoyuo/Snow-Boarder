using UnityEngine;

public class DameSender : MonoBehaviour
{

    [SerializeField] protected int dame = 1;

    public virtual void Send(Transform obj)
    {
        PlayerLivesController playerLivesController = obj.GetComponentInChildren<PlayerLivesController>();
        if (playerLivesController == null) return;
        this.Send(playerLivesController);
    }

    public virtual void Send(PlayerLivesController playerLivesController)
    {
        playerLivesController.RemoveLive(this.dame);
    }
}
