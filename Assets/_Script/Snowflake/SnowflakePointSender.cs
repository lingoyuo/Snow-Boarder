using UnityEngine;

public class SnowflakePointSender : PointSender
{
    public override void Send(PointReceive pointReceive)
    {
        base.Send(pointReceive);
        this.DestroyStar();
    }

    protected virtual void DestroyStar()
    {
        //this.starCtrl.StarDespawn.DespawnObject();
    }
}
