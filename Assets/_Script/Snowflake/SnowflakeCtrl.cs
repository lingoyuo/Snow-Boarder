using UnityEngine;

public class SnowflakeCtrl : MainBehavior
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    [SerializeField] protected PointSender pointSender;
    public PointSender PointSender { get => pointSender; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadPointSender();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
    }

    protected virtual void LoadPointSender()
    {
        if (this.pointSender != null) return;
        this.pointSender = transform.GetComponentInChildren<PointSender>();
    }
}
