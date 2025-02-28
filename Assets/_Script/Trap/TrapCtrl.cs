using UnityEngine;

public class TrapCtrl : MainBehavior
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    [SerializeField] protected DameSender damageSender;
    public DameSender DamageSender { get => damageSender; }

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
        if (this.damageSender != null) return;
        this.damageSender = transform.GetComponentInChildren<DameSender>();
    }
}
