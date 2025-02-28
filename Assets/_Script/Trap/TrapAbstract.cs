using UnityEngine;

public class TrapAbstract : MainBehavior
{
    [Header("Trap Abtract")]
    [SerializeField] protected TrapCtrl trapCtrl;
    public TrapCtrl TrapCtrl { get => trapCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStarAbstract();
    }

    protected virtual void LoadStarAbstract()
    {
        if (this.trapCtrl != null) return;
        this.trapCtrl = transform.parent.GetComponent<TrapCtrl>();
    }
}
