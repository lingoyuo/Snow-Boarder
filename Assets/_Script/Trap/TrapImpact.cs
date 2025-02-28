using UnityEngine;

public class TrapImpact : TrapAbstract
{
    [Header("Trap Impart")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        this.trapCtrl.DamageSender.Send(other.transform);
    }
}
