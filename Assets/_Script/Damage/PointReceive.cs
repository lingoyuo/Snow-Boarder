using UnityEngine;

public class PointReceive : MonoBehaviour
{
    [Header("Point Receiver")]
    [SerializeField] public int point = 0;

    public virtual void AddPoint(int point)
    {
        this.point += point;
    }
}
