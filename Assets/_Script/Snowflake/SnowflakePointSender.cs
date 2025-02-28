using UnityEngine;

public class SnowflakePointSender : PointSender
{
    public override void Send(PointReceive pointReceive)
    {
        base.Send(pointReceive);

        if (transform.parent != null)
        {
            Destroy(transform.parent.gameObject); 
        }
    }
}
