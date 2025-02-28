using UnityEngine;

public class SnowflakeImpact : SnowflakeAbstract
{
    [Header("Snowflake Impart")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        this.snowflakeCtrl.PointSender.Send(other.transform);
    }
}
