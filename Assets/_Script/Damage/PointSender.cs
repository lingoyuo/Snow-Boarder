using UnityEngine;

public class PointSender : MonoBehaviour
{
    [SerializeField] protected int point = 1;

    public virtual void Send(Transform obj)
    {
        PointReceive pointReceive = obj.GetComponentInChildren<PointReceive>();
        if (pointReceive == null) return;
        this.Send(pointReceive);
    }

    public virtual void Send(PointReceive pointReceive)
    {
        pointReceive.AddPoint(this.point);
    }
}
