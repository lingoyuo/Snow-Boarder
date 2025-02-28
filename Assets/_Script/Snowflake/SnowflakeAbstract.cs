using UnityEngine;

public class SnowflakeAbstract : MainBehavior
{
    [Header("Snowflake Abtract")]
    [SerializeField] protected SnowflakeCtrl snowflakeCtrl;
    public SnowflakeCtrl SnowflakeCtrl { get => snowflakeCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStarAbstract();
    }

    protected virtual void LoadStarAbstract()
    {
        if (this.snowflakeCtrl != null) return;
        this.snowflakeCtrl = transform.parent.GetComponent<SnowflakeCtrl>();
    }
}
