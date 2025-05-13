using UnityEngine;

public class EnemyDespawn : Despawn<T>
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.isDespawnByTime = false;
    }
}
